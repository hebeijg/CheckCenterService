using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckCenterService.BLL;
using CheckCenterService.Model;
using CheckCenterService.Web.Commo;

namespace CheckCenterService.Web.SystemManager
{
    public partial class RoleList : PageBase
    {
        public int RoleId
        {
            get
            {
                int roleId = 0;

                if (ViewState["RoleId"] != null)
                {
                    int.TryParse(ViewState["RoleId"].ToString(), out roleId);
                }

                return roleId;
            }

            set
            {
                ViewState["RoleId"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            InitGridView();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            RoleBll roleBll = new RoleBll();

            RoleInfo roleInfo = roleBll.GetRoleByName(txtRoleName.Text.Trim());

            if (roleInfo != null && roleInfo.RoleId > 0)
            {
                if (roleInfo.RoleId != RoleId)
                {
                    MessageBox.Show(this.UpdatePanel1, this.GetType(), "存在相同的角色");
                    
                    return;
                }
            }
            roleInfo = GetModel();

            if (RoleId == 0)
            {
                roleBll.AddRole(roleInfo);
            }
            else
            {
                roleInfo.RoleId = RoleId;

                roleBll.UpdateRole(roleInfo);
            }
            MessageBox.Show(this.UpdatePanel1, this.GetType(), "保存成功！");
            InitGridView();
            txtRoleName.Text = "";
        }
        private void InitGridView()
        {
            RoleBll roleBll = new RoleBll();

            List<RoleInfo> roleList = roleBll.GetAllRole();

          
            if (roleList.Count > 0)
            {
                gvRoleList.DataSource = roleList;
                gvRoleList.DataBind();
            }
            else
            {
                BindNotRecord(gvRoleList);
            }
           
        }

        private RoleInfo GetModel()
        {
            RoleInfo roleInfo = new RoleInfo();

            roleInfo.RoleName = txtRoleName.Text.Trim();
            roleInfo.Introduction = txtRoleName.Text.Trim();

            return roleInfo;
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lbtnEdit = (LinkButton)sender;
            int roleId = 0;
            int.TryParse(lbtnEdit.ToolTip, out roleId);
            RoleId = roleId;

            RoleBll roleBll = new RoleBll();

            RoleInfo roleInfo = roleBll.GetRoleById(RoleId);

            if (roleInfo != null)
            {
                txtRoleName.Text = roleInfo.RoleName;

                txtRoleName.Focus();
            }
        }
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            LinkButton lbtnDelete = (LinkButton)sender;


            DataControlFieldCell dcf = (DataControlFieldCell)lbtnDelete.Parent;
            GridViewRow gvr = (GridViewRow)dcf.Parent;

            int roleId = 0;
            int.TryParse(gvRoleList.DataKeys[gvr.RowIndex][0].ToString(), out roleId);

            RoleId = roleId;

            RoleBll roleBll = new RoleBll();

            RoleInfo roleInfo = roleBll.GetRoleById(RoleId);

            if (roleInfo != null)
            {
                roleBll.DeleteRoleById(RoleId);

               
                RoleId = 0; ;

                InitGridView();
            }

        }
        protected void gvRoleList_RowDataBound(object sender, GridViewRowEventArgs e)
        { }
    }
}