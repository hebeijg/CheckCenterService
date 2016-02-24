using CheckCenterService.BLL;
using CheckCenterService.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckCenterService.Web.SystemManager
{
    public partial class UserList : System.Web.UI.Page
    {
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
            if(IsPostBack==false)
            {
                InitGridView();
                if(DepartmentId==0)
                {
                    btnAdd.Enabled = false;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            InitGridView();
        }
        private void InitGridView()
        {
            string userIdOrUserName = txtUserName.Text.Trim();
            UserInfoBll userInfoBll = new UserInfoBll();

            DataSet ds= userInfoBll.GetUserList(userIdOrUserName, DepartmentId);

            gvUserList.DataSource = ds;
            gvUserList.DataBind();
        }
       

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
          
            int userId = 0;
            int.TryParse(((System.Web.UI.WebControls.WebControl)sender).ToolTip, out userId);

            UserInfoBll userInfoBll = new UserInfoBll();

            userInfoBll.DeleteByUserId(userId);
            Page.RegisterClientScriptBlock("", "<script>alert('删除成功');</script>");
            InitGridView();
           
        }

    }
}