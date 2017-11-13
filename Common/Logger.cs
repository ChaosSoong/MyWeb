using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    /* ==============================================================================
   * 创 建 者：宋伟超
   * 创建日期：2017/11/13 9:45:53
   * 功能描述：
   *
   * 修改者：         
   * 修改时间：       
   * 修改说明:
   * ==============================================================================*/
    public static class Logger
    {
        static string LogPath = System.Configuration.ConfigurationManager.AppSettings["IsSynPath"];
        /// <summary>
        /// 日志记录
        /// </summary>
        /// <param name="userSessionName">用户名</param>
        /// <param name="message">日志内容</param>
        public static void writeLog(string message)
        {
            HttpContext current = HttpContext.Current;
            DirectoryInfo dinfo = new DirectoryInfo(current.Server.MapPath("~/Log/Info"));
            if (!dinfo.Exists)
            {
                dinfo.Create();
            }
            string filePath = "/Log/Info/Info_" + DateTime.Today.ToString("yyyyMMdd") + ".log";
            filePath = current.Server.MapPath("~/") + filePath;
            //string user = userName;
            StreamWriter sw = new StreamWriter(filePath, true, Encoding.Default);
            sw.WriteLine("=============================================================");
            //sw.WriteLine("用户名：" + user);
            sw.WriteLine("时间：" + DateTime.Now.ToString());
            //sw.WriteLine("IP：" + current.Request.UserHostAddress);
            sw.WriteLine("日志内容：");
            sw.WriteLine(message);
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }

        /// <summary>
        /// 日志异常记录
        /// </summary>
        /// <param name="exception">捕获的异常对象</param>
        /// <param name="information">产生异常的其他相关信息（比如参数，或SQL语句）</param>
        public static void ErrorLog(Exception ex, Dictionary<string, string> information)
        {
            HttpContext current = HttpContext.Current;
            DirectoryInfo dinfo = new DirectoryInfo(current.Server.MapPath("~/Log/Error"));
            if (!dinfo.Exists)
            {
                dinfo.Create();
            }
            string filePath = "/Log/Error/Error_" + DateTime.Today.ToString("yyyy-MM-dd") + ".log";
            filePath = current.Server.MapPath("~/") + filePath;
            StreamWriter sw = new StreamWriter(filePath, true, Encoding.Default);
            sw.WriteLine("=============================================================");
            sw.WriteLine("====时间：" + DateTime.Now.ToString());
            sw.WriteLine("====IP：" + current.Request.UserHostAddress);
            sw.WriteLine("====异常内容：");
            sw.WriteLine(ex.ToString());
            if (information != null && information.Keys.Count > 0)
            {
                sw.WriteLine("====相关信息：");
                foreach (var temp in information.Keys)
                {
                    sw.WriteLine("——" + temp + "：");
                    sw.WriteLine(information[temp]);
                }
            }
            sw.WriteLine();
            sw.WriteLine();
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
    }
}
