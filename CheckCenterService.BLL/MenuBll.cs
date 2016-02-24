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
    public class MenuBll
    {
        public List<MenuInfo> GetMenuListByParentId(int parentId)
        {
            List<MenuInfo> lstMenuInfo = new List<MenuInfo>();

            MenuDal dal = new MenuDal();

            DataSet ds = dal.GetMenuListByParentId(parentId);

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstMenuInfo.Add(ConvertToModel(dr));
                }
            }
            return lstMenuInfo;
        }

        public List<MenuInfo> GetMenuListByParentIdAdnUserId(int parentId, int userId)
        {
            List<MenuInfo> lstMenuInfo = new List<MenuInfo>();

            MenuDal dal = new MenuDal();

            DataSet ds = dal.GetMenuListByParentIdAdnUserId(parentId, userId);

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstMenuInfo.Add(ConvertToModel(dr));
                }
            }
            return lstMenuInfo;
        }

        public List<MenuInfo> GetMenuListByUserId(int userId)
        {
            MenuDal dal = new MenuDal();

            DataSet ds = dal.GetRoleListByUserId(userId);
            List<MenuInfo> lstMenuInfo = new List<MenuInfo>();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstMenuInfo.Add(ConvertToModel(dr));
                }
            }

            return lstMenuInfo;
        }

        private MenuInfo ConvertToModel(DataRow dr)
        {

            MenuInfo menuInfo = new MenuInfo();

            if (dr != null)
            {
                if(dr["MenuId"] is DBNull ==false)
                {
                    int menuId = 0;
                    int.TryParse(dr["MenuId"].ToString(), out menuId);
                    menuInfo.MenuId = menuId;
                }

                if (dr["MenuName"] is DBNull == false)
                {
                    menuInfo.MenuName = dr["MenuName"].ToString();
                }

                if (dr["MenuURL"] is DBNull == false)
                {
                    menuInfo.MenuURL = dr["MenuURL"].ToString();
                }

                if (dr["Introduction"] is DBNull == false)
                {
                    menuInfo.Introduction = dr["Introduction"].ToString();
                }

                if (dr["IsUsed"] is DBNull == false)
                {
                    bool isUsed = false;
                    bool.TryParse(dr["IsUsed"].ToString(), out isUsed);
                    menuInfo.IsUsed = isUsed;
                }

                if (dr["ParentId"] is DBNull == false)
                {
                    int parentId = 0;
                    int.TryParse(dr["ParentId"].ToString(), out parentId);
                    menuInfo.ParentId = parentId;
                }
            }
            return menuInfo;
        }
    }
}
