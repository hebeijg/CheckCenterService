using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CheckCenterService.Model;
using System.Data.SqlClient;
using System.Data;

namespace CheckCenterService.DAL
{
    public class ProjectDal
    {
        public void Add(ProjectInfo projectInfo)
        {
            string sql = "   insert into P_Project(ProjectName,CreatedUserId,CreateDate,CustomerId,BussinessUserId) values(@ProjectName,@CreatedUserId,@CreateDate,@CustomerId,@BussinessUserId)";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@ProjectName", projectInfo.ProjectName);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@CreatedUserId", projectInfo.CreatedUserId);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@CreateDate", projectInfo.CreateDate);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@CustomerId", projectInfo.CustomerId);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@BussinessUserId", projectInfo.BussinessUserId);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }

        public void Update(ProjectInfo projectInfo)
        {
            string sql = "  update P_Project set ProjectName = @ProjectName, ModiftyUserId = @ModiftyUserId, ModiftyDate = @ModiftyDate, CustomerId = @CustomerId, BussinessUserId = @BussinessUserId ";
            sql += " where ProjectId =@ProjectId";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@ProjectName", projectInfo.ProjectName);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@ModiftyUserId", projectInfo.ModiftyUserId);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@ModiftyDate", projectInfo.ModiftyDate);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@CustomerId", projectInfo.CustomerId);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@BussinessUserId", projectInfo.BussinessUserId);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@ProjectId", projectInfo.ProjectId);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }

        public void UpdateResponse(int projectId, int responseUserId)
        {
            string sql = "  update P_Project set ResponseUserId =@ResponseUserId where ProjectId =@ProjectId";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@ResponseUserId", responseUserId);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@ProjectId", projectId);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }

        public void Delete(int projectId)
        {
            string sql = " delete P_Project where ProjectId=@ProjectId";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@ProjectId", projectId);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }

        public DataSet GetProjectById(int projectId)
        {
            string sql = " select * from P_Project where ProjectId=@ProjectId";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@ProjectId", projectId);
            lstParamter.Add(paramter);

            return SQLHelp.GetDataSet(sql, lstParamter);

        }
        public DataSet GetManagermentProject(string searchCondition)
        {
            string sql = " select p.*,c.CustomerName,u.UserName as BusinessManagerName,u1.UserName as ResponseName ,u2.UserName as ManagermentName from P_Project p ";
            sql += " left join P_Customer c on p.CustomerId = c.CustomerId";
            sql += " left join U_UserInfo u on u.UserId = p.BussinessUserId ";
            sql += " left join U_UserInfo u1 on u1.UserId = p.ResponseUserId ";
            sql += " left join U_UserInfo u2 on u2.UserId = p.CreatedUserId ";
            sql += " where 1=1" + searchCondition;

            return SQLHelp.GetDataSet(sql,null);
        } 
    }
}
