using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopBridge.Controllers
{
    public class ProductsController : Controller
    {
        ProductDAL objcontact = new ProductDAL();

        // GET: Contact
        public static List<Product> lstContact = new List<Product>();


        public ActionResult Index()
        {

            List<Product> lstContact = new List<Product>();
            lstContact = ProductDAL.GetAllProducts().ToList();
            return View(lstContact);

        }
       }
}
