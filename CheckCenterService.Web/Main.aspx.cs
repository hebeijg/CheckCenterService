using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckCenterService.Web
{
    public partial class Main : System.Web.UI.Page
    {
        public string frameSet = "";
        protected void Page_Load(object sender, EventArgs e)
        {
          
            frameSet += " <html xmlns='http://www.w3.org/1999/xhtml'>";
            frameSet += " <head>";

            frameSet += " <title>质量检测系统</title>";
            frameSet += " </head>";
            frameSet += " <frameset border='0' framespacing='0' rows='68,5,*,15' frameborder='no' cols='*'> ";

            frameSet += "  <frame id='topFrame' name='topFrame' src='Top.aspx?token=" + Session["token"] + "&isPass=0' noResize scrolling='no'></frame>";

            frameSet += "   <frame id='topBarFrame' title='topBarFrame' name='topBarFrame' src='topBar.htm' noResize scrolling='no'></frame> ";

            frameSet += "  <frameset id='bFrame' border='0' framespacing='0' frameborder='no' cols='168,6,*'> ";

            frameSet += " <frame id='leftFrame' name='leftFrame' src='LeftMenu.aspx?token=" + Session["token"] + "&isPass=0' noResize scrolling='no'></frame> ";

            frameSet += "    <frame id='leftBarFrame' title='leftBarFrame' name='leftBarFrame' src='leftBarTemp.htm' noResize scrolling='no'></frame>";
            /*启用跳转到修改密码开关并查询日志是否已经修改密码*/
            frameSet += "  <frame id='mainFrame' width='auto'  name='mainFrame' src='ProjectManager/BusinessProjectList.aspx?token=" + Session["token"] + "&isPass=0'  ></frame>";

            frameSet += "   </frameset> ";

            frameSet += "    <frame id='bottomBarFrame' title='bottomBarFrame' name='bottomBarFrame' src='Bottom.aspx?token=" + Session["token"] + "&isPass=0' noResize scrolling='no'></frame>";

            frameSet += "    </frameset> ";
            frameSet += "</html>";
            Response.Write(frameSet);
        }
    }
}