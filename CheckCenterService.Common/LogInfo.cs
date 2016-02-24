using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CheckCenterService.Common
{
    public class LogInfo
    {
        /// <summary>
        /// 把异常信息写入到本地Log文件中
        /// </summary>
        /// <param name="action"></param>
        /// <param name="description"></param>
        public static void WriteLog(string action, string description)
        {

            try
            {
                string path = System.Environment.CurrentDirectory  + "\\Log";
                if (!File.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filePath = path + "\\ClientLog.txt";
                FileStream fs = new FileStream(filePath, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + action + " | " + description);
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {

            }


        }
    }
}
