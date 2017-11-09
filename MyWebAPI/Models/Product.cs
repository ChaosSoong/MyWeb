using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebAPI.Models
{
    public class Product
    {
        public string id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string image { get; set; }
    }
}