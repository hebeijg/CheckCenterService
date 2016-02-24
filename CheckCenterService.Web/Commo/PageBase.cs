using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckCenterService.Model;
using CheckCenterService.BLL;

namespace CheckCenterService.Web.Commo
{
    public class PageBase : System.Web.UI.Page
    {
        public LoginUserInfo LoginUser
        {
            get
            {
                LoginUserInfo loginUserInfo = new LoginUserInfo();
                if(Session["LoginUser"] !=null)
                {
                    loginUserInfo = (LoginUserInfo)Session["LoginUser"];
                }
                return loginUserInfo;
            }
            set
            {
                Session["LoginUser"]=value;
            }
        }

        public bool Login(UserInfo userInfo,string password)
        {
            bool isSuccess = false;

            if (userInfo != null&&userInfo.Password ==password)
            {
                LoginUserInfo loginUser = new LoginUserInfo();

                loginUser.UserCode = userInfo.UserCode;
                loginUser.UserName = userInfo.UserName;
                loginUser.UserId = userInfo.UserId;
                loginUser.CreateDate = userInfo.CreatedDate;
                loginUser.Department = GetDepartmentByDepartmetCode(userInfo.DepartmentCode);
                loginUser.RoleList = GetRoleListByUserId(userInfo.UserId);
                loginUser.MenuInfos = GetMenuListByUserId(userInfo.UserId);

                LoginUser = loginUser;

                isSuccess = true;

            }

            return isSuccess;
        }

        public List<RoleInfo> GetRoleListByUserId(int userId)
        {
            RoleBll roleBll = new RoleBll();

            return roleBll.GetRoleListByUserId(userId);
        }

        public List<MenuInfo> GetMenuListByUserId(int userId)
        {
            MenuBll menuBll = new MenuBll();
            return menuBll.GetMenuListByUserId(userId);
        }

        public DepartmentInfo GetDepartmentByDepartmetCode(string departmentCode)
        {
            DepartmentBll departmentBll = new DepartmentBll();

            return departmentBll.GetDepartmentInfoByDepartmentCode(departmentCode);


        }
        public void BindNotRecord(GridView gv)
        {
            Hashtable ht = new Hashtable();
            string dataField = "";
            foreach (DataControlField d in gv.Columns)
            {

                if (d is BoundField)
                {
                    dataField = ((System.Web.UI.WebControls.BoundField)(d)).DataField;
                }
                else if (d is TemplateField)
                {
                    dataField = ((System.Web.UI.WebControls.TemplateField)(d)).AccessibleHeaderText;
                }

                if (dataField != "")
                {
                    if (ht[dataField] == null)
                    {
                        ht.Add(dataField, dataField);
                    }
                }
            }

            foreach (string dataKeyNames in gv.DataKeyNames)
            {
                if (dataKeyNames != "")
                {
                    if (ht[dataKeyNames] == null)
                    {
                        ht.Add(dataKeyNames, dataKeyNames);
                    }
                }
            }
            DataTable dt = new DataTable();
            foreach (string key in ht.Keys)
            {
                DataColumn dc = new DataColumn(key);

                dt.Columns.Add(dc);

            }

            dt.Rows.Add(dt.NewRow());

            gv.DataSource = dt;

            gv.DataBind();

            int columnCount = gv.Columns.Count;

            gv.Rows[0].Cells.Clear();
            gv.Rows[0].Cells.Add(new TableCell());
            gv.Rows[0].Cells[0].ColumnSpan = columnCount;

            gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;

            gv.Rows[0].Cells[0].Text = "暂无数据";


        }

    }
}
