using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /* ==============================================================================
   * 创 建 者：宋伟超
   * 创建日期：2017/11/13 9:05:39
   * 功能描述：
   *
   * 修改者：         
   * 修改时间：       
   * 修改说明:
   * ==============================================================================*/
    public static class StringFilter
    {
        /// <summary>
        /// SHA1加密方法
        /// </summary>
        /// <param name="str">传入的明文</param>
        /// <returns>加密后的密文</returns>
        public static string getSHA1Code(string str)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] str1 = Encoding.UTF8.GetBytes(str);
            byte[] str2 = sha1.ComputeHash(str1);
            sha1.Clear();
            (sha1 as IDisposable).Dispose();
            return BitConverter.ToString(str2).Replace("-", "");
        }
    }
}
