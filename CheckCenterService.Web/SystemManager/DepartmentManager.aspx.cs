using CheckCenterService.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckCenterService.Web.SystemManager
{
    public partial class DepartmentManager : System.Web.UI.Page
    {
        public string TreeJsonStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            DepartmentBll departmentBll = new DepartmentBll();
            TreeJsonStr = departmentBll.GetDTreeJsonStr();
        }
    }
}