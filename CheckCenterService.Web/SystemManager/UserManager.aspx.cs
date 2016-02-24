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
    public partial class UserManager : System.Web.UI.Page
    {
        public string TreeJsonStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            DepartmentBll departmentBll = new DepartmentBll();
            TreeJsonStr = departmentBll.GetDTreeJsonStr();
        }
    }
}