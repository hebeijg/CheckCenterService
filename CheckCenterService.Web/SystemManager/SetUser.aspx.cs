using CheckCenterService.BLL;
using CheckCenterService.Model;
using CheckCenterService.Web.Commo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckCenterService.Web.SystemManager
{
    public partial class SetUser : PageBase
    {
        public int RoleId
        {
            get
            {
                int roleId = 0;
                if (string.IsNullOrEmpty(Request.QueryString["Id"]) == false)
                {
                    int.TryParse(Request.QueryString["Id"].ToString(), out roleId);
                }
                return roleId;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitExistGridView();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            RoleUserBll roleUserBll = new RoleUserBll();

            List<RoleUserInfo> roleUserList = this.GetModel();

            roleUserBll.DeleteRoleUserByRoleId(RoleId);

            roleUserBll.AddRoleUser(roleUserList);

          
            Response.Redirect("RoleList.aspx?token=" + Session["token"]);
        }
        public string GetTeamByName(object departmentId)
        {
            return "";
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            InitNotExistUserGridView();

            InitExistGridView();
        }
        private void InitNotExistUserGridView()
        {
    
            UserInfoBll userBll = new UserInfoBll();
            List<UserInfo> userList = userBll.GetNotUserListByRoleId(RoleId,txtUserIdOrName.Text.Trim(),txtDepartment.Text.Trim());

            if (userList.Count > 0)
            {
                gvNotExistsUserList.DataSource = userList;

                gvNotExistsUserList.DataBind();
            }
            else
            {
                BindNotRecord(gvNotExistsUserList);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoleList.aspx?token=" + Session["token"]);
        }
        private List<RoleUserInfo> GetModel()
        {
            List<RoleUserInfo> roleUserList = new List<RoleUserInfo>();

            GetSelectUserId(gvExistsUserList, roleUserList);

            GetSelectUserId(gvNotExistsUserList, roleUserList);

            return roleUserList;
        }

        private void GetSelectUserId(GridView gv, List<RoleUserInfo> roleUserList)
        {
            foreach (GridViewRow row in gv.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("cbSelectUser");

                if (cb != null && cb.Checked == true && cb.ToolTip != "")
                {
                    RoleUserInfo roleUserInfo = new RoleUserInfo();

                    roleUserInfo.UserId = Convert.ToInt32(cb.ToolTip);

                    roleUserInfo.RoleId = RoleId;

                    roleUserList.Add(roleUserInfo);
                }
            }
        }
        private void InitExistGridView()
        {
            RoleBll roleBll = new RoleBll();

            RoleInfo roleInfo = roleBll.GetRoleById(RoleId);

            if (roleInfo != null)
            {
                lblCurrentRoleName.Text = roleInfo.RoleName;
            }


            UserInfoBll userBll = new UserInfoBll();
            
            List<UserInfo> userList = userBll.GetUserListByRoleId(RoleId);

            if (userList.Count > 0)
            {
                gvExistsUserList.DataSource = userList;

                gvExistsUserList.DataBind();
            }
            else
            {
                BindNotRecord(gvExistsUserList);
            }

        }

    }
}