using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckCenterService.BLL;
using CheckCenterService.Model;
namespace CheckCenterService.Web.SystemManager
{
    public partial class SetRole : System.Web.UI.Page
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
            InitMenuList();
            if (IsPostBack == false)
            {
                InitData();
            }
        }
        public void InitData()
        {
            RoleBll roleBll = new RoleBll();

            RoleInfo roleInfo = roleBll.GetRoleById(RoleId);

            if (roleInfo != null)
            {
                lblCurrentRoleName.Text = roleInfo.RoleName;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<RoleMenuInfo> roleMenuList = GetRoleMenuModel();

            

            RoleMenuBll roleMenuBll = new RoleMenuBll();

            roleMenuBll.DeleteRoleMenuByRoleId(RoleId);

            roleMenuBll.AddRoleMenu(roleMenuList);

          
            Response.Redirect("RoleList.aspx?token=" + Session["token"]);
        }

        private void InitMenuList()
        {
            MenuBll menuBll = new MenuBll();

            List<MenuInfo> menuList = menuBll.GetMenuListByParentId(0);

            RoleMenuBll roleMenuBll = new RoleMenuBll();

            List<RoleMenuInfo> roleMenuList =  roleMenuBll.GetRoleMenuListByRoleId(RoleId);


            if (menuList != null)
            {
                RoleBll roleBll = new RoleBll();

                RoleInfo roleInfo = roleBll.GetRoleById(RoleId);

                if (roleInfo == null)
                {
                    return;
                }
                foreach (MenuInfo menuInfo in menuList)
                {
                   
                    Label lbl = new Label();

                    lbl.Text = menuInfo.MenuName;

                    trMenuList.Controls.Add(lbl);

                    List<MenuInfo> subMenuList = menuBll.GetMenuListByParentId(menuInfo.MenuId);


                    CheckBoxList cbList = new CheckBoxList();

                    cbList.ID = "menuInfo_" + menuInfo.MenuId;

                    cbList.RepeatDirection = RepeatDirection.Horizontal;

                    cbList.RepeatColumns = 4;

                    cbList.DataSource = subMenuList;
                    cbList.DataTextField = "MenuName";

                    cbList.DataValueField = "MenuId";

                    cbList.DataBind();

                    
                    foreach (ListItem li in cbList.Items)
                    {
                       
                        if (roleMenuList != null)
                        {
                            foreach (RoleMenuInfo roleMenu in roleMenuList)
                            {
                                if (li.Value == roleMenu.MenuId.ToString())
                                {
                                    li.Selected = true;
                                }
                            }
                        }
                   
                    }
                    trMenuList.Controls.Add(cbList);
                }
            }
        }


        /// <summary>
        /// 获取角色和菜单关联关系
        /// </summary>
        /// <returns>角色和菜单关联关系列表</returns>
        private List<RoleMenuInfo> GetRoleMenuModel()
        {
            List<RoleMenuInfo> roleMenuInfoList = new List<RoleMenuInfo>();

            MenuBll menuBll = new MenuBll();

            List<MenuInfo> menuList = menuBll.GetMenuListByParentId(0);

            if (menuList != null)
            {
                foreach (MenuInfo menu in menuList)
                {
                    CheckBoxList cbList = (CheckBoxList)trMenuList.FindControl("menuInfo_" + menu.MenuId);

                    if (cbList != null)
                    {
                        foreach (ListItem li in cbList.Items)
                        {
                            if (li.Selected == true)
                            {
                                RoleMenuInfo roleMenuInfo = new RoleMenuInfo();

                                roleMenuInfo.MenuId = Convert.ToInt32(li.Value);

                                roleMenuInfo.RoleId = RoleId;

                                roleMenuInfoList.Add(roleMenuInfo);
                            }
                        }
                    }
                }
            }
            return roleMenuInfoList;
        }
    }
}