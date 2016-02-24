using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckCenterService.BLL;
using System.Data;
using CheckCenterService.Model;
using CheckCenterService.Web.Commo;

namespace CheckCenterService.Web.ProjectManager
{
    public partial class ProjectEdit : PageBase
    {
        public int ProjectId
        {
            get
            {
                int projectId = 0;

                if(Request.QueryString["ProjectId"] !=null)
                {
                    int.TryParse(Request.QueryString["ProjectId"].ToString(), out projectId);
                }
                return projectId;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack==false)
            {
                InitCustomer();

                if(ProjectId>0)
                {
                    InitData();
                }
            }
        }

        private void InitData()
        {
            ProjectBll projectBll = new ProjectBll();

            ProjectInfo projectInfo = projectBll.GetProjectById(ProjectId);

            if(projectInfo!=null &&projectInfo.ProjectId>0)
            {
                txtProjectName.Text = projectInfo.ProjectName;

                ddlCustomerList.SelectedValue = projectInfo.CustomerId.ToString();

                UserInfoBll userInfoBll = new UserInfoBll();

                UserInfo userInfo = userInfoBll.GetUserListById(projectInfo.BussinessUserId);

                if(userInfo != null)
                {
                    lblBusinessName.Text = userInfo.UserName;
                    hidUserId.Value = userInfo.UserId.ToString();
                }
            }
        }

        private void InitCustomer()
        {
            CustomerBll customerBll = new CustomerBll();

            DataSet ds = customerBll.GetAllCustomer();

            ddlCustomerList.DataSource = ds;

            ddlCustomerList.DataTextField = "CustomerName";
            ddlCustomerList.DataValueField = "CustomerId";

            ddlCustomerList.DataBind();

            ddlCustomerList.Items.Insert(0, new ListItem("--请选择--", "0"));
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

           
            ProjectBll projectBll = new ProjectBll();

            ProjectInfo projectInfo = GetModel();

            
            if (ProjectId == 0)
            {
             
                projectBll.Add(projectInfo);

            }
            else
            {
                projectInfo.ProjectId = ProjectId;
                projectBll.Update(projectInfo);
            }


            Page.RegisterClientScriptBlock("", "<script>alert('保存成功');</script>");

            Response.Redirect("ManagementProjectList.aspx");
        }

        private ProjectInfo GetModel()
        {
            ProjectInfo projectInfo = new ProjectInfo();

            projectInfo.ProjectName = txtProjectName.Text.Trim();
            projectInfo.CreatedUserId = LoginUser.UserId;
            projectInfo.CreateDate = DateTime.Now;
            projectInfo.ModiftyUserId = LoginUser.UserId;
            projectInfo.ModiftyDate = DateTime.Now;
            projectInfo.CustomerId = Convert.ToInt32(ddlCustomerList.SelectedValue);
            projectInfo.BussinessUserId = Convert.ToInt32(hidUserId.Value);
            return projectInfo;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagementProjectList.aspx");
        }
    }
}