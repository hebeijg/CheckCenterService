using CheckCenterService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckCenterService.DAL;
using System.Data;

namespace CheckCenterService.BLL
{
    public class RoleUserBll
    {
        public void AddRoleUser(RoleUserInfo roleUserInfo)
        {
            RoleUserDal dal = new RoleUserDal();
            dal.AddRoleMenu(roleUserInfo);
        }

        public void AddRoleUser(List<RoleUserInfo> lstRoleUserInfo)
        {
            if(lstRoleUserInfo!=null)
            {
                foreach(RoleUserInfo roleUserInfo in lstRoleUserInfo)
                {
                    AddRoleUser(roleUserInfo);
                }
            }
        }
        public List<RoleUserInfo> GetRoleUserListByRoleId(int roleId)
        {
            List<RoleUserInfo> lstRoleUser = new List<RoleUserInfo>();

            RoleUserDal dal = new RoleUserDal();

            DataSet ds = dal.GetRoleUserByRoleId(roleId);

            if(ds!=null &&ds.Tables.Count>0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    lstRoleUser.Add(ConvertToModel(dr));
                }
            }

            return lstRoleUser;
        }

        public void DeleteRoleUserByRoleId(int roleId)
        {
            RoleUserDal dal = new RoleUserDal();
            dal.DeleteRoleUserByRoleId(roleId);
        }

        private RoleUserInfo ConvertToModel(DataRow dr)
        {
            RoleUserInfo roleUserInfo = new RoleUserInfo();
            if (dr != null)
            {
                if (dr["RoleId"] is DBNull == false)
                {
                    int roleId = 0;
                    int.TryParse(dr["RoleId"].ToString(), out roleId);
                    roleUserInfo.RoleId = roleId;
                }

                if (dr["UserId"] is DBNull == false)
                {
                    int userId = 0;
                    int.TryParse(dr["UserId"].ToString(), out userId);
                    roleUserInfo.UserId = userId;
                }
            }
            return roleUserInfo;
        }
    }
}
