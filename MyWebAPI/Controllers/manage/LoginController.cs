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
        MyWebEntities db = new MyWebEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form) {
            string user = form["username"].ToString();
            string pwd = Common.StringFilter.getSHA1Code(form["password"].ToString());
            int count = db.SysUser.Where(m => m.name == user && m.pwd == pwd).ToList().Count();
            if (count > 0)
            {
                return Redirect(Url.Content("~/Product/Index" + ""));
            }
            else {
                return Content("null");
            }
        }
        public ActionResult Validator()
        {
            try
            {
                Common.Validator vali = new Common.Validator();
                string code = vali.GenerateCheckCode(5);
                Session["ValidateStr"] = code;
                byte[] imgstream = vali.CreateCheckCodeImage(code);
                return File(imgstream, "image/jpg");
            }
            catch (Exception ex)
            {
                return Content("<script>alert('下载过程出现错误，请联系管理员');history.go(-1);</script>");
            }
        }
    }
}