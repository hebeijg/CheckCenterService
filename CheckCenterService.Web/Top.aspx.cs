using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckCenterService.Web
{
    public partial class Top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnLogOut_Click(object sender, EventArgs e)
        {
            //AddLog(LoginUser.UserId, DateTime.Now, ModuleNameEnum.UserLogin, OperateTypeEnum.LogOut, true, LoginUser.UserId + "在 " + DateTime.Now + " 退出");

            //FormsAuthentication.SignOut();
            //Session.Abandon();
            //MessageBox.Redirct(Page, "LoginTemp.aspx");
        }
    }
}