using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckCenterService.Model;
using CheckCenterService.DAL;
using System.Data;

namespace CheckCenterService.BLL
{
    public class RoleBll
    {
        public void AddRole(RoleInfo roleInfo)
        {
            RoleDal dal = new RoleDal();

            dal.AddRole(roleInfo);
        }
        public void UpdateRole(RoleInfo roleInfo)
        {
            RoleDal dal = new RoleDal();

            dal.UpdateRole(roleInfo);
        }

        public void DeleteRoleById(int roleId)
        {
            RoleDal dal = new RoleDal();

            dal.DeleteRoleById(roleId);
        }
        public RoleInfo GetRoleByName(string roleName)
        {
            RoleDal dal = new RoleDal();

            DataSet ds = dal.GetRoleByName(roleName);
            RoleInfo roleInfo = new RoleInfo();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                roleInfo = ConvertToModel(ds.Tables[0].Rows[0]);
            }
            
            return roleInfo;
        }

        public List<RoleInfo> GetAllRole()
        {
            List<RoleInfo> lstRoleInfo = new List<RoleInfo>();

            RoleDal dal = new RoleDal();
            DataSet ds = dal.GetAllRoleInfo();

            if (ds != null && ds.Tables.Count > 0 )
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    RoleInfo roleInfo = ConvertToModel(dr);
                    lstRoleInfo.Add(roleInfo);
                }
            }

            return lstRoleInfo;
        }
        public RoleInfo GetRoleById(int roleId)
        {
            RoleDal dal = new RoleDal();

            DataSet ds = dal.GetRoleById(roleId);
            RoleInfo roleInfo = new RoleInfo();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                roleInfo = ConvertToModel(ds.Tables[0].Rows[0]);
            }

            return roleInfo;
        }

        public List<RoleInfo> GetRoleListByUserId(int userId)
        {

            RoleDal dal = new RoleDal();

            DataSet ds = dal.GetRoleListByUserId(userId);
            List<RoleInfo> lstRoleInfo = new List<RoleInfo>();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    lstRoleInfo.Add(ConvertToModel(dr));
                }
            }

            return lstRoleInfo;
        }

        private RoleInfo ConvertToModel(DataRow dr)
        {
            RoleInfo roleInfo = new RoleInfo();

            if(dr!=null)
            {
                if (dr["RoleId"] is DBNull == false)
                {
                    int roleId = 0;
                    int.TryParse(dr["RoleId"].ToString(), out roleId);
                    roleInfo.RoleId = roleId;
                }

                if (dr["RoleName"] is DBNull == false)
                {
                    roleInfo.RoleName = dr["RoleName"].ToString();
                }

                if (dr["Introduction"] is DBNull == false)
                {
                    roleInfo.Introduction = dr["Introduction"].ToString();
                }
            }
            return roleInfo;
        }
    }
}
