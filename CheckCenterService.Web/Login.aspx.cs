using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckCenterService.BLL;
using CheckCenterService.Model;
using CheckCenterService.Web.Commo;

namespace CheckCenterService.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogin_Click(null, null);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userCode = "fanruiquan";// txtUserName.Text.Trim();
            string password = "123456";// txtPassword.Text.Trim();

            UserInfoBll userBll = new UserInfoBll();

            UserInfo userInfo = userBll.GetUserByCode(userCode);

            PageBase pageBase = new PageBase();

            if(pageBase.Login(userInfo,password ))
            {
                Response.Redirect("Main.aspx");
            }
         

        }
    }
}