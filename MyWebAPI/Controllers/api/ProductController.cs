using Filter;
using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebAPI.Controllers
{
    [SystemAutherFilter]
    public class ProductController : ApiController
    {
        WebEntities db = new WebEntities();
        [HttpGet]
        public List<Product> getAllProducts() {
            List<Product> list = db.Product.ToList();
            return list;
        }
        [HttpGet]
        public Product getProduct(string id) {
            Product p = new Product();
            p.id = 1;
            p.name = "chao";
            p.price = 25;
            return p;
        }
    }
}
