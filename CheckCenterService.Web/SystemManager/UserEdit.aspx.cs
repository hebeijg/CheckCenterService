using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckCenterService.Model;
using CheckCenterService.Common;
using CheckCenterService.BLL;
namespace CheckCenterService.Web.SystemManager
{
    public partial class UserEdit : System.Web.UI.Page
    {
        public int UserId
        {
            get
            {
                int uUserId = 0;
                if (string.IsNullOrEmpty(Request.QueryString["UserId"]) == false)
                {
                    int.TryParse(Request.QueryString["UserId"].ToString(), out uUserId);
                }
                return uUserId;
            }

        }

        public int DepartmentId
        {
            get
            {
                int departmentId = 0;
                if (string.IsNullOrEmpty(Request.QueryString["department"]) == false)
                {
                    int.TryParse(Request.QueryString["department"].ToString(), out departmentId);
                }
                return departmentId;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack ==false)
            {
                if (UserId != 0)
                {
                    InitData();
                }
            }
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = GetModel();

            UserInfoBll bll = new UserInfoBll();

            if (UserId == 0)
            {
                DepartmentBll departmentBll = new DepartmentBll();
                DepartmentInfo departmentInfo = departmentBll.GetDepartmentById(DepartmentId);
                if (departmentInfo != null && departmentInfo.DepartmentId > 0)
                {
                    userInfo.DepartmentCode = departmentInfo.DepartmentCode;
                }
                bll.AddUserInfo(userInfo);

            }
            else
            {
                userInfo.UserId = UserId;
                bll.Update(userInfo);
            }

            Page.RegisterClientScriptBlock("", "<script>alert('保存成功');CloseWin();</script>");
        }

        private void InitData()
        {
            UserInfoBll userInfoBll = new UserInfoBll();
            UserInfo userInfo = userInfoBll.GetUserListById(UserId);

            if(userInfo!=null)
            {
                txtUserID.Text = userInfo.UserCode;
                txtUserName.Text = userInfo.UserName;
                txtTle.Text = userInfo.TelPhone;
                txtMoblie.Text = userInfo.MobilePhone;
                txtMail.Text = userInfo.EMail; 
            }
        }
        private UserInfo GetModel()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.UserCode = txtUserID.Text.Trim();
            userInfo.UserName = txtUserName.Text.Trim();
            userInfo.Password = GetDefaultPassword();
            userInfo.CreatedDate = DateTime.Now;
            userInfo.TelPhone = txtTle.Text.Trim();
            userInfo.MobilePhone = txtMoblie.Text.Trim();
            userInfo.EMail = txtMail.Text.Trim();
            return userInfo;
        }

        private string GetDefaultPassword()
        {
            return ConfigurationOpteration.GetStringByKey("DefaultPassword");
        }
       
    }
}