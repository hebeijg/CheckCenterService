using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckCenterService.DAL;
using System.Data;
using CheckCenterService.Model;
namespace CheckCenterService.BLL
{
    public class UserInfoBll
    {
     
        public DataSet GetUserDataByCode(string userCode)
        {
            UserInfoDal dal = new UserInfoDal();

            return dal.GetUserDataByCode(userCode);
        }

        public DataSet GetUserDataById(int userId)
        {
            UserInfoDal dal = new UserInfoDal();

            return dal.GetUserDataById(userId);
        }

        public void AddUserInfo(UserInfo userInfo)
        {

            UserInfoDal dal = new UserInfoDal();

            dal.AddUserInfo(userInfo);
        }

        public void Update(UserInfo userInfo)
        {

            UserInfoDal dal = new UserInfoDal();

            dal.Update(userInfo);
        }

        public void DeleteByUserId(int userId)
        {
            UserInfoDal dal = new UserInfoDal();

            dal.DeleteByUserId(userId);
        }
        public List<UserInfo> GetUserListByRoleId(int roleId)
        {
            List<UserInfo> lstUserInfo = new List<UserInfo>();
            UserInfoDal dal = new UserInfoDal();

            DataSet ds = dal.GetUserListByRoleId(roleId);

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstUserInfo.Add(ConvertToModel(dr));
                }
            }

            return lstUserInfo;
        }

        public DataSet  GetUserList(string userIdOrUserName,int departmentId)
        {
            UserInfoDal dal = new UserInfoDal();

            return  dal.GetUserList(userIdOrUserName, departmentId);

        }

        
        public UserInfo GetUserByCode(string userCode)
        {
            UserInfo userInfo = new UserInfo();
            DataSet ds = GetUserDataByCode(userCode);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                userInfo = ConvertToModel(ds.Tables[0].Rows[0]);
            }

            return userInfo;
        }

        public UserInfo GetUserListById(int  userId)
        {
            UserInfo userInfo = new UserInfo();
            DataSet ds = GetUserDataById(userId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                userInfo = ConvertToModel(ds.Tables[0].Rows[0]);
            }

            return userInfo;
        }
        public List<UserInfo> GetNotUserListByRoleId(int roleId, string userCode, string departmentName)
        {
            List<UserInfo> lstUserInfo = new List<UserInfo>();

            UserInfoDal dal = new UserInfoDal();
            DataSet ds = dal.GetNotUserListByRoleId(roleId, userCode, departmentName);

            if(ds!=null&&ds.Tables.Count>0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstUserInfo.Add(ConvertToModel(dr));
                }
            }

            return lstUserInfo;
        }
        private UserInfo ConvertToModel(DataRow dr)
        {
            UserInfo userInfo = new UserInfo();

            if (dr != null)
            {
                if (dr["UserId"] is DBNull == false)
                {
                    int userId = 0;
                    int.TryParse(dr["UserId"].ToString(), out userId);
                    userInfo.UserId = userId;
                }


                if (dr["UserCode"] is DBNull == false)
                {
                    userInfo.UserCode = dr["UserCode"].ToString();
                }
                if (dr["UserName"] is DBNull == false)
                {
                    userInfo.UserName = dr["UserName"].ToString();
                }
                if (dr["Password"] is DBNull == false)
                {
                    userInfo.Password = dr["Password"].ToString();
                }
                if (dr["DepartmentCode"] is DBNull == false)
                {
                    userInfo.DepartmentCode = dr["DepartmentCode"].ToString();
                }
                if (dr["CreatedDate"] is DBNull == false)
                {
                    DateTime createdDate = DateTime.Now;
                    DateTime.TryParse(dr["CreatedDate"].ToString(), out createdDate);
                    userInfo.CreatedDate = createdDate;
                }
                if (dr["TelPhone"] is DBNull == false)
                {
                    userInfo.TelPhone = dr["TelPhone"].ToString();
                }
                if (dr["MobilePhone"] is DBNull == false)
                {
                    userInfo.MobilePhone = dr["MobilePhone"].ToString();
                }
                if (dr["EMail"] is DBNull == false)
                {
                    userInfo.EMail = dr["EMail"].ToString();
                }
            }
            return userInfo;
        }
    }
}
