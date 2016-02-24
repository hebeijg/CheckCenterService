using CheckCenterService.BLL;
using CheckCenterService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckCenterService.Web.SystemManager
{
    public partial class DepartmentEdit : System.Web.UI.Page
    {
        public int ParementDpartmentId
        {
            get
            {
                int parentDepartment = 0;
                if (string.IsNullOrEmpty(Request.QueryString["parentDepartment"]) == false)
                {
                    int.TryParse(Request.QueryString["parentDepartment"].ToString(), out parentDepartment);
                }
                return parentDepartment;
            }

        }

        public int DepartmentId
        {
            get
            {
                int departmentId = 0;
                if (string.IsNullOrEmpty(Request.QueryString["departmentId"]) == false)
                {
                    int.TryParse(Request.QueryString["departmentId"].ToString(), out departmentId);
                }
                return departmentId;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (DepartmentId != 0)
                {
                    InitData();
                }
            }
        }
        private void InitData()
        {
          
            DepartmentBll departmentBll = new DepartmentBll();
           DepartmentInfo departmentInfo = departmentBll.GetDepartmentById(DepartmentId);
            if (departmentInfo != null)
            {
                txtDepartmentCode.Text = departmentInfo.DepartmentCode;
                txtDepartmentName.Text = departmentInfo.DepartmentName;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DepartmentInfo departmentInfo = GetModel();

            DepartmentBll departmentBll = new DepartmentBll();

            if (DepartmentId == 0)
            {
                departmentBll.AddDepartment(departmentInfo);
            }
            else
            {
                departmentInfo.DepartmentId = DepartmentId;
                departmentBll.Update(departmentInfo);
            }

            Page.RegisterClientScriptBlock("", "<script>alert('保存成功');CloseWin();</script>");
        }
        private DepartmentInfo GetModel()
        {
            DepartmentInfo deparmentInfo = new DepartmentInfo();

            deparmentInfo.DepartmentCode = txtDepartmentCode.Text.Trim();
            deparmentInfo.DepartmentName = txtDepartmentName.Text.Trim();
            deparmentInfo.Introduction = txtDepartmentName.Text.Trim();
            deparmentInfo.CreatedDate = DateTime.Now;
            deparmentInfo.ParentId = ParementDpartmentId;

            return deparmentInfo;
        }
    }

   

    
}