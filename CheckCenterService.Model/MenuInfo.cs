using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckCenterService.Model
{
    public class MenuInfo
    {
        public int MenuId
        {
            get;
            set;
        }

        public string MenuName
        {
            get;
            set;
        }

        public string MenuURL
        {
            get;
            set;
        }

        public string Introduction
        {
            get;
            set;
        }

        public bool IsUsed
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
