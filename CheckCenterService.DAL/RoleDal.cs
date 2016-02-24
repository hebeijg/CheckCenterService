using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckCenterService.Model;
using System.Data.SqlClient;
using System.Data;

namespace CheckCenterService.DAL
{
    public class RoleDal
    {
        public void AddRole(RoleInfo roleInfo)
        {
            string sql = "insert into U_RoleInfo(RoleName,Introduction)values(@RoleName,@Introduction)";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@RoleName", roleInfo.RoleName);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@Introduction", roleInfo.Introduction);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }

        public void UpdateRole(RoleInfo roleInfo)
        {
            string sql = "update U_RoleInfo set RoleName=@RoleName,Introduction=@Introduction where RoleId=@RoleId";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@RoleName", roleInfo.RoleName);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@Introduction", roleInfo.Introduction);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@RoleId", roleInfo.RoleId);
            lstParamter.Add(paramter);
            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }

        public void DeleteRoleById(int roleId)
        {
            string sql = " delete U_RoleInfo where RoleId =@RoleId";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@RoleId", roleId);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }
        public DataSet GetRoleByName(string roleName)
        {
            string sql = "select * from U_RoleInfo where RoleName=@RoleName";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@RoleName", roleName);
            lstParamter.Add(paramter);

            return SQLHelp.GetDataSet(sql, lstParamter);
        }

        public DataSet GetAllRoleInfo()
        {
            string sql = "select * from U_RoleInfo";

            return SQLHelp.GetDataSet(sql, null);
        }

        public DataSet GetRoleById(int roleId)
        {
            string sql = "select * from U_RoleInfo where RoleId=@RoleId";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@RoleId", roleId);
            lstParamter.Add(paramter);

            return SQLHelp.GetDataSet(sql, lstParamter);
        }

        public DataSet GetRoleListByUserId(int userId)
        {
            string sql = "select r.* from U_RoleInfo r  inner join S_UserRole ur on r.RoleId = ur.RoleId where ur.UserId =@UserId";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@UserId", userId);
            lstParamter.Add(paramter);

            return SQLHelp.GetDataSet(sql, lstParamter);

        }
    }
}
