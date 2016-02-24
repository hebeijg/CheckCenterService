using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckCenterService.Model
{
    public class ProjectInfo
    {
        public int ProjectId
        {
            get;
            set;
        }

        public string ProjectName
        {
            get;
            set;
        }

        public int CreatedUserId
        {
            get;
            set;
        }

        public DateTime CreateDate
        {
            get;
            set;
        }

        public int ModiftyUserId
        {
            get;
            set;
        }

        public DateTime ModiftyDate
        {
            get;
            set;
        }

        public int CustomerId
        {
            get;
            set;
        }

        public int BussinessUserId
        {
            get;
            set;
        }

        public int ResponseUserId
        {
            get;
            set;
        }
    }
}
