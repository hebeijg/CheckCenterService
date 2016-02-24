using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckCenterService.DAL;
using CheckCenterService.Model;

namespace CheckCenterService.BLL
{
    public class DepartmentBll
    {
        public void AddDepartment(DepartmentInfo departmentInfo)
        {
            DepartmentDal dal = new DepartmentDal();

            dal.AddDepartment(departmentInfo);
        }

        public void Update(DepartmentInfo departmentInfo)
        {
            DepartmentDal dal = new DepartmentDal();

            dal.Update(departmentInfo);
        }

        public void DeleteById(int departmentId)
        {
            DepartmentDal dal = new DepartmentDal();
            dal.DeleteById(departmentId);
        }
        public DataSet GetAllDepartment()
        {
            DepartmentDal dal = new DepartmentDal();
            return dal.GetAllDepartment();
        }

        public DepartmentInfo GetDepartmentInfoByDepartmentCode(string departmentCode)
        {
            DepartmentInfo departmentInfo = new DepartmentInfo();

            DepartmentDal dal = new DepartmentDal();

            DataSet ds = dal.GetDepartmentInfoByDepartmentCode(departmentCode);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                departmentInfo = ConvertToModel(ds.Tables[0].Rows[0]);
            }

            return departmentInfo;
        }

        public DataSet GetDepartmentList(string departmentCodeOrName, int parentDepartmentId)
        {
            DepartmentDal dal = new DepartmentDal();
            return dal.GetDepartmentList(departmentCodeOrName, parentDepartmentId);
        }
        public DepartmentInfo GetDepartmentById(int departmentId)
        {
            DepartmentInfo departmentInfo = new DepartmentInfo();

            DepartmentDal dal = new DepartmentDal();

            DataSet ds = dal.GetDepartmentById(departmentId);

            if(ds!=null &&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
            {
                departmentInfo = ConvertToModel(ds.Tables[0].Rows[0]);
            }

            return departmentInfo;
        }
        public string GetDTreeJsonStr()
        {
            DataSet  data =  GetAllDepartment();
            StringBuilder Json = new StringBuilder();
            Json.Append("[");
            Json.Append("{");
            Json.AppendFormat("id:{0}, pId:{1}, name: \"{2}\",desc:\"{3}\"", 0, -1, "所有部门", "所有部门");
            Json.Append("},");
           

            foreach (DataRow item in data.Tables[0].Rows)
            {
                

                Json.Append("{");
                if (item["ParentId"] == DBNull.Value)
                {
                    Json.AppendFormat("id:{0}, pId:{1}, name: \"{2}\",desc:\"{3}\"", item["DepartmentId"], 0, item["DepartmentCode"], item["DepartmentName"] ?? string.Empty);
                }
                else
                {
                    Json.AppendFormat("id:{0}, pId:{1}, name: \"{2}\",desc:\"{3}\"", item["DepartmentId"], item["ParentId"], item["DepartmentCode"], item["DepartmentName"] ?? string.Empty);
                }

                Json.Append("},");
            }
            Json.Remove(Json.Length - 1, 1);
            Json.Append("]");
            return Json.ToString();
          
        }

        private DepartmentInfo ConvertToModel(DataRow dr)
        {
            DepartmentInfo departmentInfo = new DepartmentInfo();

            if (dr != null)
            {
                if (dr["DepartmentId"] is DBNull == false)
                {
                    int departmentId = 0;
                    int.TryParse(dr["DepartmentId"].ToString(), out departmentId);
                    departmentInfo.DepartmentId = departmentId;
                }

                if (dr["DepartmentCode"] is DBNull == false)
                {
                    departmentInfo.DepartmentCode = dr["DepartmentCode"].ToString();
                }

                if (dr["DepartmentName"] is DBNull == false)
                {
                    departmentInfo.DepartmentName = dr["DepartmentName"].ToString();
                }

                if (dr["Introduction"] is DBNull == false)
                {
                    departmentInfo.Introduction = dr["Introduction"].ToString();
                }

                if (dr["CreatedDate"] is DBNull == false)
                {
                    DateTime createdDate = DateTime.MinValue;
                    DateTime.TryParse(dr["CreatedDate"].ToString(), out createdDate);
                    departmentInfo.CreatedDate = createdDate;
                }

                if (dr["ParentId"] is DBNull == false)
                {
                    int parentId = 0;
                    int.TryParse(dr["ParentId"].ToString(), out parentId);
                    departmentInfo.ParentId = parentId;
                }
            }
            return departmentInfo;
        }

    }
}
