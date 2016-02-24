using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckCenterService.Common
{
    public class ConfigurationOpteration
    {
        public static string GetStringByKey(string key)
        {
           return  System.Configuration.ConfigurationManager.AppSettings[key];
        }


    }
}
