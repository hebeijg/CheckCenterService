using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckCenterService.DAL
{
    public class MenuDal
    {
        public DataSet GetMenuListByParentId(int parentId)
        {
            string sql = " select * from S_Menu where ParentId=@ParentId";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@ParentId", parentId);
            lstParamter.Add(paramter);

            return SQLHelp.GetDataSet(sql, lstParamter);
        }
        public DataSet GetMenuListByParentIdAdnUserId(int parentId, int userId)
        {
            string sql = "select  m.* from S_Menu m inner join S_RoleMenu rm on m.MenuId = rm.MenuId ";

            sql += " inner join S_UserRole ur on ur.RoleId = rm.RoleId where ur.UserId =@UserId and m.ParentId =@ParentId";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@UserId", userId);
            lstParamter.Add(paramter);

            paramter = new SqlParameter("@ParentId", parentId);
            lstParamter.Add(paramter);

            return SQLHelp.GetDataSet(sql, lstParamter);
        }
        public DataSet GetRoleListByUserId(int userId)
        {
            string sql = " select distinct m.* from  S_Menu m  ";
            sql += " inner join(";
            sql += " select  m.* from S_Menu m inner join S_RoleMenu rm on m.MenuId = rm.MenuId inner join S_UserRole ur on ur.RoleId = rm.RoleId where ur.UserId =@UserId";
            sql += ") t on t.ParentId =m.MenuId ";
            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@UserId", userId);
            lstParamter.Add(paramter);

            return SQLHelp.GetDataSet(sql, lstParamter);

        }
    }
}
