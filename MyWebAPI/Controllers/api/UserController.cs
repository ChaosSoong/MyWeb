using Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MyWebAPI.Controllers
{
    [SystemAutherFilter]
    public class UserController : Controller
    {
        WebEntities db = new WebEntities();
        #region 后台用户管理
        public ActionResult addSysUser(int id)
        {
            SysUser user = new SysUser();
            user.id = id;
            user.username = "song";
            user.password = "123456o-0";
            db.SysUser.Add(user);
            db.SaveChanges();
            return Content("add ok");
        }
        /// <summary>
        /// 删除管理用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult delSysUser(int id)
        {
            SysUser user = new SysUser() { id = id };
            db.SysUser.Attach(user);
            db.SysUser.Remove(user);
            db.SaveChanges();
            return Content("del ok");
        }
        #endregion

        #region 前端用户管理

        #endregion
    }
}
