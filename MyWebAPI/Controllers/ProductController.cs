using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebAPI.Controllers
{
    public class ProductController : ApiController
    {
        MyWebEntities db = new MyWebEntities();
        [HttpGet]
        public List<SysUser> getAllProducts() {
            List<SysUser> list = db.SysUser.ToList();
            return list;
        }
        [HttpGet]
        public Product getProduct(string id) {
            Product p = new Product();
            p.id = "1";
            p.name = "chao";
            p.price = 25;
            return p;
        }
    }
}
