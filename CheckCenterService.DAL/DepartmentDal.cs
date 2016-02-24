using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckCenterService.Model;
namespace CheckCenterService.DAL
{
    public class DepartmentDal
    {
        public void AddDepartment(DepartmentInfo departmentInfo)
        {
            string sql = "  insert into U_Department (DepartmentCode,DepartmentName,Introduction,CreatedDate,ParentId)";
            sql += " values(@DepartmentCode,@DepartmentName,@Introduction,@CreatedDate,@ParentId)";

            List<SqlParameter> lstParamter = new List<SqlParameter>();
            SqlParameter paramter = new SqlParameter("@DepartmentCode", departmentInfo.DepartmentCode);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@DepartmentName", departmentInfo.DepartmentName);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@Introduction", departmentInfo.Introduction);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@CreatedDate", departmentInfo.CreatedDate);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@ParentId", departmentInfo.ParentId);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }

        public void Update(DepartmentInfo departmentInfo)
        {
            string sql = " update U_Department set DepartmentCode=@DepartmentCode, DepartmentName=@DepartmentName   where DepartmentId =@DepartmentId";

            List<SqlParameter> lstParamter = new List<SqlParameter>();
            SqlParameter paramter = new SqlParameter("@DepartmentCode", departmentInfo.DepartmentCode);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@DepartmentName", departmentInfo.DepartmentName);
            lstParamter.Add(paramter);
            paramter = new SqlParameter("@DepartmentId", departmentInfo.DepartmentId);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }

        public void DeleteById(int departmentId)
        {
            string sql = "delete U_Department where DepartmentId=@DepartmentId";
            List<SqlParameter> lstParamter = new List<SqlParameter>();
            SqlParameter paramter = new SqlParameter("@DepartmentId", departmentId);
            lstParamter.Add(paramter);

            SQLHelp.ExecuteNonQuery(sql, lstParamter);
        }
        public DataSet GetAllDepartment()
        {
            string sql = "select * from U_Department ";
            return SQLHelp.GetDataSet(sql, null);

        }

        public DataSet GetDepartmentById(int departmentId)
        {
            string sql = "select * from U_Department where DepartmentId=@DepartmentId";
            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@DepartmentId", departmentId);
            lstParamter.Add(paramter);

            return SQLHelp.GetDataSet(sql, lstParamter);
        }

        public DataSet GetDepartmentInfoByDepartmentCode(string  departmentCode)
        {
            string sql = "select * from U_Department where DepartmentCode=@DepartmentCode";
            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@DepartmentCode", departmentCode);
            lstParamter.Add(paramter);

            return SQLHelp.GetDataSet(sql, lstParamter);
        }

        public DataSet GetDepartmentList(string departmentCodeOrName, int parentDepartmentId)
        {
            string sql = " select * from U_Department  ";
            sql += " where 1=1";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            if (departmentCodeOrName != "")
            {
                sql += "  and( DepartmentCode like '%"+ departmentCodeOrName + "%' or DepartmentName like '%"+ departmentCodeOrName + "%')";
               
            }

            if (parentDepartmentId != 0)
            {
                sql += "  and ParentId=@ParentDepartmentId";
                SqlParameter paramter = new SqlParameter("@ParentDepartmentId", parentDepartmentId);
                lstParamter.Add(paramter);
            }



            DataSet ds = SQLHelp.GetDataSet(sql, lstParamter);

            return ds;
        }
    }
}
