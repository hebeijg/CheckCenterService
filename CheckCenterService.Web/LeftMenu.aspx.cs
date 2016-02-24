using CheckCenterService.BLL;
using CheckCenterService.Model;
using CheckCenterService.Web.Commo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckCenterService.Web
{

    public partial class LeftMenu : PageBase
    {
        public string MenuUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuBll menuBll = new MenuBll();

            // List<MenuInfo> menuList = menuBll.GetTopMenuListByRoleId(LoginUser.RoleList);
            List<MenuInfo> menuList = LoginUser.MenuInfos;
           
            for (int i = 0; i < menuList.Count; i++)
            {
                MenuInfo menu = menuList[i];

                string menuName = menu.MenuName;

                int menuId = menu.MenuId;
                MenuUrl += "<div id='mainMenu" + i + "' onclick=Show(" + i + ")  class='MainClass'>" + menuName + "</div>";

                MenuUrl += "<div id='subMenu" + i + "' style='width:98%;overflow:auto' class='SubClass'>";
                List<MenuInfo> subMenuList = menuBll.GetMenuListByParentIdAdnUserId( menuId,LoginUser.UserId);

              
                for (int j = 0; j < subMenuList.Count; j++)
                {
                    MenuInfo subMenu = subMenuList[j];
                    string subMenuName = subMenu.MenuName;

                    string url = subMenu.MenuURL;
                 
                    //MenuUrl += "<div onclick=SubMenuClick(this,img" + i + "_" + j + ",link" + i + "_" + j + ")  >";
                    MenuUrl += "<div   >";
                    MenuUrl += "<img id='img" + i + "_" + j + "' alt='' src='images/箭头黑.png'/>&nbsp;&nbsp;&nbsp;&nbsp;";
                    MenuUrl += "<a id='link" + i + "_" + j + "' href='" + url + "'>" + subMenuName + "</a><br>";

                    MenuUrl += "</div>";
                }

                MenuUrl += "</div>";
            }
        }    
    }
}