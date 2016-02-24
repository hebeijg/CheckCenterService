using CheckCenterService.BLL;
using CheckCenterService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckCenterService.Web.ProjectManager
{
    public partial class ProjectSetResponse : System.Web.UI.Page
    {
        public int ProjectId
        {
            get
            {
                int projectId = 0;

                if (Request.QueryString["ProjectId"] != null)
                {
                    int.TryParse(Request.QueryString["ProjectId"].ToString(), out projectId);
                }
                return projectId;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(ProjectId>0)
            {
                InitData();
            }
        }

        private void InitData()
        {
            ProjectBll projectBll = new ProjectBll();

            ProjectInfo projectInfo = projectBll.GetProjectById(ProjectId);

            if (projectInfo != null)
            {
                lblProjectName.Text = projectInfo.ProjectName;
                if (projectInfo.CustomerId > 0)
                {
                    CustomerBll customerBll = new CustomerBll();

                    CustomerInfo customerInfo = customerBll.GetCustomerById(projectInfo.CustomerId);

                    if (customerInfo != null)
                    {
                        lblCustomerName.Text = customerInfo.CustomerName;
                    }
                }
                if (projectInfo.BussinessUserId > 0)
                {
                    UserInfoBll userInfoBll = new UserInfoBll();

                    UserInfo userInfo = userInfoBll.GetUserListById(projectInfo.BussinessUserId);

                    if (userInfo != null)
                    {
                        lblBusinessName.Text = userInfo.UserName;
                    }
                }

                if (projectInfo.ResponseUserId > 0)
                {
                    UserInfoBll userInfoBll = new UserInfoBll();

                    UserInfo userInfo = userInfoBll.GetUserListById(projectInfo.ResponseUserId);

                    if (userInfo != null)
                    {
                        lblResponseName.Text = userInfo.UserName;
                    }

                    hidUserId.Value = projectInfo.ResponseUserId.ToString();
                }

                if (projectInfo.CreatedUserId > 0)
                {
                    UserInfoBll userInfoBll = new UserInfoBll();

                    UserInfo userInfo = userInfoBll.GetUserListById(projectInfo.CreatedUserId);

                    if (userInfo != null)
                    {
                        lblCreateUser.Text = userInfo.UserName;
                    }
                }


            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {


            ProjectBll projectBll = new ProjectBll();

            int responseUserId = 0;
            int.TryParse(hidUserId.Value, out responseUserId);
            projectBll.UpdateResponse(ProjectId, responseUserId);


            Page.RegisterClientScriptBlock("", "<script>alert('保存成功');</script>");

            Response.Redirect("BusinessProjectList.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BusinessProjectList.aspx");
        }
    }
}