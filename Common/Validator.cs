using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace Common
{
    /* ==============================================================================
   * 创 建 者：宋伟超
   * 创建日期：2017/11/13 9:36:33
   * 功能描述：
   *
   * 修改者：         
   * 修改时间：       
   * 修改说明:
   * ==============================================================================*/
    public class Validator
    {
        /// <summary>
        /// 生成指定长度的验证码
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string GenerateCheckCode(int length)
        {
            int number;
            char code;
            string checkCode = String.Empty;

            System.Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                number = random.Next();

                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));

                checkCode += code.ToString();
            }

            return checkCode;
        }

        public byte[] CreateCheckCodeImage(string checkCode)
        {
            if (checkCode == null || checkCode.Trim() == String.Empty)
                return null;

            Bitmap image = new Bitmap(100, 28);
            Graphics g = Graphics.FromImage(image);
            checkCode = string.Join(" ", Regex.Matches(checkCode, ".").Cast<Match>().ToList());
            try
            {
                //生成随机生成器
                Random random = new Random();

                //清空图片背景色
                g.Clear(ColorTranslator.FromHtml("#162538"));

                //画图片的背景噪音线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);

                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                Font font = new Font("Arial", 16, (FontStyle.Bold | FontStyle.Italic));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), ColorTranslator.FromHtml("#41707C"), ColorTranslator.FromHtml("#41707C"), 1.4f, true);
                g.DrawString(checkCode, font, brush, 4, 4);

                //画图片的前景噪音点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //画图片的边框线
                g.DrawRectangle(new Pen(ColorTranslator.FromHtml("#263738")), 0, 0, image.Width - 1, image.Height - 1);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
    }
}
