using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebAPI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MyWebEntities entity = new MyWebEntities();
        public ActionResult Index()
        {
            List<SysUser> list = entity.SysUser.ToList();
            ViewBag.list = list;
            return View();
        }
        public ActionResult addSysUser(string id) {
            SysUser user = new SysUser();
            user.id = id;
            user.name = "song";
            user.pwd = "123456o-0";
            entity.SysUser.Add(user);
            entity.SaveChanges();
            return Content("add ok");
        }
        public ActionResult delSysUser(string id) {
            SysUser user = new SysUser() { id = id };
            entity.SysUser.Attach(user);
            entity.SysUser.Remove(user);
            entity.SaveChanges();
            return Content("del ok");
        }
    }
}