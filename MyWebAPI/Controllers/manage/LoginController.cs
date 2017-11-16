using Common;
using Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebAPI.Controllers
{
    [SystemAutherFilter]
    public class LoginController : Controller
    {
        WebEntities db = new WebEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form) {
            string user = form["username"].ToString();
            string pwd = StringFilter.getSHA1Code(form["password"].ToString());
            string validate = form["validate"].ToString().ToUpper();
            string validateSession = Session["ValidateStr"].ToString();
            if (validate != validateSession) {
                return Content("<script>alert('验证码错误');history.go(-1);</script>");
            }
            else{
                int count = db.SysUser.Where(m => m.username == user && m.password == pwd).ToList().Count();
                if (count > 0)
                {
                    return Redirect(Url.Content("~/Product/Index" + ""));
                }
                else
                {
                    return Content("<script>alert('账号或密码错误');history.go(-1);</script>");
                }
            }
        }
        public ActionResult Validator()
        {
            try
            {
                Validator vali = new Validator();
                string code = vali.GenerateCheckCode(5);
                Session["ValidateStr"] = code;
                byte[] imgstream = vali.CreateCheckCodeImage(code);
                return File(imgstream, "image/jpg");
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ex, new Dictionary<string, string>() { { "Function", "LoginController.Validator()[HttpGet]" } });
                return Content("<script>alert('下载过程出现错误，请联系管理员');history.go(-1);</script>");
            }
        }
    }
}