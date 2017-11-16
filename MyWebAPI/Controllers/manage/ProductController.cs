using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebAPI.Controllers.manage
{
    public class ProductController : Controller
    {
        WebEntities db = new WebEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
    }
}