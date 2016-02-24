using CheckCenterService.BLL;
using CheckCenterService.Web.Commo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckCenterService.Web.ProjectManager
{
    public partial class BusinessProjectList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitGridView();

            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            InitGridView();
        }
     
        private void InitGridView()
        {
            string searchConditon = " and p.BussinessUserId=" + LoginUser.UserId;
            string projectName = txtProjectName.Text.Trim();

            if (txtProjectName.Text.Trim() != "")
            {
                searchConditon += " and p.ProjectName like '%" + txtProjectName.Text.Trim() + "%'";
            }

            ProjectBll projectbll = new ProjectBll();
            DataSet ds = projectbll.GetManagermentProject(searchConditon);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvDepartmentList.DataSource = ds;
                gvDepartmentList.DataBind();
            }
            else
            {
                BindNotRecord(gvDepartmentList);
            }
         
        }
        protected void lbtnEdit_Click(object sender, EventArgs e)
        {

            int projectId = 0;
            int.TryParse(((System.Web.UI.WebControls.WebControl)sender).ToolTip, out projectId);

            Response.Redirect("ProjectSetResponse.aspx?ProjectId=" + projectId);

        }

    }
}