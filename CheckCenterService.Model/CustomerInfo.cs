using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckCenterService.Model
{
    public class CustomerInfo
    {
        public int CustomerId
        {
            get;
            set;
        }

        public string CustomerName
        {
            get;
            set;
        }

        public string CustomerAddress
        {
            get;
            set;
        }

        public string CustomerContact
        {
            get;
            set;
        }

        public int CreatedUserId
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public int ModeifityUserId
        {
            get;
            set;
        }

        public DateTime  ModifityDate
        {
            get;
            set;
        }
    }
}
