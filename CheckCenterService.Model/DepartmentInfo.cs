using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckCenterService.Model
{
    public class DepartmentInfo
    {
        public int DepartmentId
        {
            get;
            set;
        }

     
        public string  DepartmentCode
        {
            get;
            set;
        }

        public string DepartmentName
        {
            get;
            set;
        }

        public string Introduction
        {
            get;
            set;
        }

        public DateTime  CreatedDate
        {
            get;
            set;
        }

        public int ParentId
        {
            get;
            set;
        }

    }
}
