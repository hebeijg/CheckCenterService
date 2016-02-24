using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CheckCenterService.Model;

namespace CheckCenterService.DAL
{
    public class UserInfoDal
    {
        public void AddUserInfo(UserInfo userInfo)
        {
            string sql = " insert into U_UserInfo(UserCode,UserName,Password,DepartmentCode,CreatedDate,TelPhone,MobilePhone,EMail)";
            sql += " values(@UserCode,@UserName,@Password,@DepartmentCode,@CreatedDate,@TelPhone,@MobilePhone,@EMail)";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@UserCode", userInfo.UserCode);
            lstParamter.Add(paramter);

            paramter = new SqlParameter("@UserName", userInfo.UserName);
            lstParamter.Add(paramter);

            paramter = new SqlParameter("@Password", userInfo.Password);
            lstParamter.Add(paramter);

            paramter = new SqlParameter("@DepartmentCode", userInfo.DepartmentCode);
            lstParamter.Add(paramter);

            paramter = new SqlParameter("@CreatedDate", userInfo.CreatedDate);
            lstParamter.Add(paramter);

            paramter = new SqlParameter("@TelPhone", userInfo.TelPhone);
            lstParamter.Add(paramter);

            paramter = new SqlParameter("@MobilePhone", userInfo.MobilePhone);
            lstParamter.Add(paramter);

            paramter = new SqlParameter("@EMail", userInfo.EMail);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);

        }
    
        public void Update(UserInfo userInfo)
        {
            string sql = "update U_UserInfo set UserCode=@UserCode,UserName=@UserName ,TelPhone=@TelPhone,MobilePhone=@MobilePhone,EMail=@EMail where UserId=@UserId";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@UserCode", userInfo.UserCode);
            lstParamter.Add(paramter);

            paramter = new SqlParameter("@UserName", userInfo.UserName);
            lstParamter.Add(paramter);

            paramter = new SqlParameter("@TelPhone", userInfo.TelPhone);
            lstParamter.Add(paramter);

            paramter = new SqlParameter("@MobilePhone", userInfo.MobilePhone);
            lstParamter.Add(paramter);

            paramter = new SqlParameter("@EMail", userInfo.EMail);
            lstParamter.Add(paramter);

            paramter = new SqlParameter("@UserId", userInfo.UserId);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }

        public void DeleteByUserId(int userId)
        {
            string sql = " delete U_UserInfo where UserId=@UserId";
            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@UserId", userId);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }
        public DataSet GetUserDataByCode(string userCode)
        {         
            string sql = "select * from U_UserInfo where UserCode =@UserCode ";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@UserCode", userCode);
            lstParamter.Add(paramter);

            DataSet ds = SQLHelp.GetDataSet(sql, lstParamter);
        
            return ds;

        }
        public DataSet GetUserDataById(int userId)
        {

            string sql = "select * from U_UserInfo where UserId =@UserId ";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@UserId", userId);
            lstParamter.Add(paramter);

            DataSet ds = SQLHelp.GetDataSet(sql, lstParamter);


            return ds;

        }
        public DataSet GetUserListByRoleId(int roleId)
        {
            string sql = "select * from U_UserInfo u inner join S_UserRole ur on u.UserId = ur.UserId where ur.RoleId =@RoleId";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@RoleId", roleId);
            lstParamter.Add(paramter);

            DataSet ds = SQLHelp.GetDataSet(sql, lstParamter);


            return ds;
        }
     
        public DataSet GetNotUserListByRoleId(int roleId,string userCode,string departmentName)
        {
            string sql = "select * from U_UserInfo u where UserId not in (select UserId from S_UserRole where RoleId=@RoleId )";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@RoleId", roleId);
            lstParamter.Add(paramter);
      
            if (userCode != "")
            {
                sql += " and (UserCode  like '%@UserName%' or UserName like '%@UserName%')";
                paramter = new SqlParameter("@UserName", userCode);
                lstParamter.Add(paramter);
            }
            if(departmentName!="")
            {
                sql += "  and DepartmentCode in (select DepartmentCode from U_Department where DepartmentCode like '%@DepartmentCode%' or DepartmentName like '%@DepartmentCode%')";
                paramter = new SqlParameter("@DepartmentCode", departmentName);
                lstParamter.Add(paramter);

            }

            DataSet ds = SQLHelp.GetDataSet(sql, lstParamter);

            return ds;
        }

        public DataSet GetUserList(string userIdOrUserName, int departmentId)
        {
            string sql = " select u.*,d.DepartmentName from U_UserInfo u inner join U_Department d on u.DepartmentCode = d.DepartmentCode ";
            sql += " where 1=1";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            if (userIdOrUserName !="")
            {
                sql += "  and( UserCode like '%"+ userIdOrUserName + "%' or UserName like '%@"+ userIdOrUserName + "%')";
              
            }

            if(departmentId != 0)
            {
                sql += "  and d.DepartmentId=@DepartmentId";
                SqlParameter paramter = new SqlParameter("@DepartmentId", departmentId);
                lstParamter.Add(paramter);
            }
            
            

            DataSet ds = SQLHelp.GetDataSet(sql, lstParamter);

            return ds;
        }
    }
}
