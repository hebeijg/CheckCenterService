using CheckCenterService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CheckCenterService.DAL;
using System.Data;

namespace CheckCenterService.BLL
{
    public class ProjectBll
    {
        public void Add(ProjectInfo projectInfo)
        {
            ProjectDal dal = new ProjectDal();

            dal.Add(projectInfo);
        }

        public void Update(ProjectInfo projectInfo)
        {
            ProjectDal dal = new ProjectDal();

            dal.Update(projectInfo);
        }

        public void UpdateResponse(int projectId,int responseUserId)
        {
            ProjectDal dal = new ProjectDal();

            dal.UpdateResponse(projectId, responseUserId);
        }
        public void Delete(int projectId)
        {
            ProjectDal dal = new ProjectDal();

            dal.Delete(projectId);
        }
        public ProjectInfo GetProjectById(int projectId)
        {
            ProjectInfo projectInfo = new ProjectInfo();

            ProjectDal dal = new ProjectDal();

            DataSet ds = dal.GetProjectById(projectId);

            if(ds!=null &&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
            {
                projectInfo = ConvertToModel(ds.Tables[0].Rows[0]);
            }

            return projectInfo;
        }
        public DataSet GetManagermentProject(string searchCondition)
        {
            ProjectDal dal = new ProjectDal();

            return dal.GetManagermentProject(searchCondition);
        }

        private ProjectInfo ConvertToModel(DataRow dr)
        {
            ProjectInfo projectInfo = new ProjectInfo();

            if(dr!=null)
            {
                if(dr["ProjectId"] is DBNull ==false)
                {
                    int projectId = 0;
                    int.TryParse(dr["ProjectId"].ToString(), out projectId);

                    projectInfo.ProjectId = projectId;
                }

                if (dr["ProjectName"] is DBNull == false)
                {
                    
                    projectInfo.ProjectName = dr["ProjectName"].ToString();
                }

                if (dr["CreatedUserId"] is DBNull == false)
                {
                    int createdUserId = 0;
                    int.TryParse(dr["CreatedUserId"].ToString(), out createdUserId);

                    projectInfo.CreatedUserId = createdUserId;
                }

                if (dr["CreateDate"] is DBNull == false)
                {
                    DateTime createDate = DateTime.MaxValue;
                    DateTime.TryParse(dr["CreateDate"].ToString(), out createDate);

                    projectInfo.CreateDate = createDate;
                }

                if (dr["ModiftyUserId"] is DBNull == false)
                {
                    int modiftyUserId = 0;
                    int.TryParse(dr["ModiftyUserId"].ToString(), out modiftyUserId);

                    projectInfo.ModiftyUserId = modiftyUserId;
                }

                if (dr["ModiftyDate"] is DBNull == false)
                {
                    DateTime modiftyDate = DateTime.MaxValue;
                    DateTime.TryParse(dr["ModiftyDate"].ToString(), out modiftyDate);

                    projectInfo.ModiftyDate = modiftyDate;
                }

                if (dr["CustomerId"] is DBNull == false)
                {
                    int customerId = 0;
                    int.TryParse(dr["CustomerId"].ToString(), out customerId);

                    projectInfo.CustomerId = customerId;
                }

                if (dr["BussinessUserId"] is DBNull == false)
                {
                    int bussinessUserId = 0;
                    int.TryParse(dr["BussinessUserId"].ToString(), out bussinessUserId);

                    projectInfo.BussinessUserId = bussinessUserId;
                }

                if (dr["ResponseUserId"] is DBNull == false)
                {
                    int responseUserId = 0;
                    int.TryParse(dr["ResponseUserId"].ToString(), out responseUserId);

                    projectInfo.ResponseUserId = responseUserId;
                }
            }
            return projectInfo;
        }
    }
}
