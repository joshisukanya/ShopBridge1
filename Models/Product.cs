using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class Product
    {
        public int id { get; set; }
        public string Name {get;set;}
        public string Description { get; set; }
        public string ErrorMsg { get; set; }
        public int Price { get; set; }
    }
}