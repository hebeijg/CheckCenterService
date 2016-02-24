using CheckCenterService.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckCenterService.Web.SystemManager
{
    public partial class DepartmentList : System.Web.UI.Page
    {
        public int ParentDepartmentId
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
            string departmentCodeOrName = txtDepatmentName.Text.Trim();
            DepartmentBll departmentBll = new DepartmentBll();

            DataSet ds = departmentBll.GetDepartmentList(departmentCodeOrName, ParentDepartmentId);

            gvDepartmentList.DataSource = ds;
            gvDepartmentList.DataBind();
        }


        protected void lbtnDelete_Click(object sender, EventArgs e)
        {

            int departmentId = 0;
            int.TryParse(((System.Web.UI.WebControls.WebControl)sender).ToolTip, out departmentId);

            DepartmentBll departmentBll = new DepartmentBll();
            departmentBll.DeleteById(departmentId);
            InitGridView();

        }
    }
}