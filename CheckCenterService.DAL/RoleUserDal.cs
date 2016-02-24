using CheckCenterService.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckCenterService.DAL
{
    public class RoleUserDal
    {
        public DataSet GetRoleUserByRoleId(int roleId)
        {
            string sql = " select * from S_UserRole where RoleId=@RoleId";
            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@RoleId", roleId);
            lstParamter.Add(paramter);

            return SQLHelp.GetDataSet(sql, lstParamter);
        }

        public void DeleteRoleUserByRoleId(int roleId)
        {
            string sql = " delete S_UserRole where RoleId=@RoleId";
            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@RoleId", roleId);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }

        public void AddRoleMenu(RoleUserInfo roleUserInfo)
        {
            string sql = "insert into S_UserRole(RoleId,UserId)values(@RoleId,@UserId)";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@RoleId", roleUserInfo.RoleId);
            lstParamter.Add(paramter);

            paramter = new SqlParameter("@UserId", roleUserInfo.UserId);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }
    }
}
