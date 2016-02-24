using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckCenterService.Model
{
    public class LoginUserInfo
    {
        public int UserId
        {
            get;
            set;
        }

        public string UserCode
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
       

        public DepartmentInfo Department
        {
            get;
            set;
        }

        public DateTime CreateDate
        {
            get;
            set;
        }

        public List<RoleInfo> RoleList
        {
            get;
            set;
        }

        public List<MenuInfo> MenuInfos
        {
            get;
            set;
        }
    }
 

}
