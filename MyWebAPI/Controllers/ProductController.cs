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
        [HttpGet]
        public List<Product> getAllProducts() {
            return null;
        }
        [HttpGet]
        public Product getProduct(string id) {
            return null;
        }
    }
}
