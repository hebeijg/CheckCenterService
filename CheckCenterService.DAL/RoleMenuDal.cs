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
    public class RoleMenuDal
    {
        public DataSet GetRoleMenuListByRoleId(int roleId)
        {
            string sql = " select * from S_RoleMenu where RoleId=@RoleId ";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@RoleId", roleId);
            lstParamter.Add(paramter);

            return SQLHelp.GetDataSet(sql, lstParamter);
        }
        public void AddRoleMenu(RoleMenuInfo roleMenuInfo)
        {
            string sql = "insert into S_RoleMenu(RoleId,MenuId)values(@RoleId,@MenuId)";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@RoleId", roleMenuInfo.RoleId);
            lstParamter.Add(paramter);

            paramter = new SqlParameter("@MenuId", roleMenuInfo.MenuId);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }
        public void DeleteRoleMenuByRoleId(int roleId)
        {
            string sql = " delete S_RoleMenu where RoleId=@RoleId";
            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@RoleId", roleId);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }
    }
}
