using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckCenterService.DAL;
using CheckCenterService.Model;
using System.Data;

namespace CheckCenterService.BLL
{
    public class RoleMenuBll
    {
        public List<RoleMenuInfo> GetRoleMenuListByRoleId(int roleId)
        {
            List<RoleMenuInfo> lstRoleMenu = new List<RoleMenuInfo>();
            RoleMenuDal dal = new RoleMenuDal();

            DataSet ds = dal.GetRoleMenuListByRoleId(roleId);

            if(ds!=null &&ds.Tables.Count>0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    lstRoleMenu.Add(ConvertToModel(dr));
                }
            }

            return lstRoleMenu;
        }
        public void AddRoleMenu(List<RoleMenuInfo> lstRoleMenu)
        {
            if (lstRoleMenu != null)
            {
                RoleMenuDal dal = new RoleMenuDal();
                foreach (RoleMenuInfo roleMenu in lstRoleMenu)
                {
                    if(roleMenu != null)
                    {
                        AddRoleMenu(roleMenu);
                    }
                }
            }
        }

        public void AddRoleMenu(RoleMenuInfo roleMenu)
        {
            RoleMenuDal dal = new RoleMenuDal();
            dal.AddRoleMenu(roleMenu);
        }
        public void DeleteRoleMenuByRoleId(int roleId)
        {
            RoleMenuDal dal = new RoleMenuDal();

            dal.DeleteRoleMenuByRoleId(roleId);
        }

        private RoleMenuInfo ConvertToModel(DataRow dr)
        {
            RoleMenuInfo roleMenuInfo = new RoleMenuInfo();

            if(dr!=null)
            {
                if(dr["RoleId"] is DBNull ==false)
                {
                    int roleId = 0;
                    int.TryParse(dr["RoleId"].ToString(), out roleId);
                    roleMenuInfo.RoleId = roleId;
                }

                if (dr["MenuId"] is DBNull == false)
                {
                    int menuId = 0;
                    int.TryParse(dr["MenuId"].ToString(), out menuId);
                    roleMenuInfo.MenuId = menuId;
                }
            }
            return roleMenuInfo;
        }
    }
}
