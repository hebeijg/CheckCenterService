using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace CheckCenterService.Web.Commo
{
    class MessageBox
    {
        public static void Show(System.Web.UI.UpdatePanel updatePanel, Type type, string message)
        {
            ScriptManager.RegisterClientScriptBlock(updatePanel, type, "updateScript", "alert('" + message + "')", true);
        }
    }
}
