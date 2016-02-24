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
    public partial class SearchUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack==false)
            {
                InitDepartment();
            }
        }

        private void InitDepartment()
        {
            DepartmentBll departmentBll = new DepartmentBll();

            DataSet ds = departmentBll.GetAllDepartment();

            ddlDepartment.DataSource = ds;
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataValueField = "DepartmentId";
            ddlDepartment.DataBind();

            ddlDepartment.Items.Insert(0, new ListItem("--请选择--", "0"));

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            UserInfoBll userInfoBll = new UserInfoBll();

            string userIdOrUserName = txtUserName.Text.Trim();
            int deparemntId = Convert.ToInt32( ddlDepartment.SelectedValue);

            
            DataSet ds = userInfoBll.GetUserList(userIdOrUserName, deparemntId);

            gvUserList.DataSource = ds;
            gvUserList.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int selectCount = 0;
            string userMessage="";
            foreach(GridViewRow  row in gvUserList.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("cbUserId");

                if (cb != null)
                {
                    if(cb.Checked== true)
                    {
                        selectCount++;
                        userMessage += gvUserList.DataKeys[row.RowIndex][0];
                        userMessage += "-"+ gvUserList.DataKeys[row.RowIndex][1];
                    }
                }
            }

            if(selectCount ==0)
            {
                Page.RegisterClientScriptBlock("", "<script>alert('请选择一条记录');</script>");
            }
            else if(selectCount ==1)
            {
                Page.RegisterClientScriptBlock("", "<script>CloseWin('"+ userMessage + "');</script>");
            }
            else
            {
                Page.RegisterClientScriptBlock("", "<script>alert('只选择一条记录');</script>");
            }
            
        }
    }
}