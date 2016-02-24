using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckCenterService.Model
{
    public class UserInfo
    {
        public int UserId
        {
            get;
            set;
        }

        public string  UserCode
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string DepartmentCode
        {
            get;
            set;
        }

        public DateTime  CreatedDate
        {
            get;
            set;
        }

        public string TelPhone
        {
            get;
            set;
        }

        public string MobilePhone
        {
            get;
            set;
        }

        public string EMail
        {
            get;
            set;
        }
    }
}
