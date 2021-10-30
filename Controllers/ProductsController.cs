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
        //public async Task<ActionResult> Index()
        //{
        //    return View(await "");
        //}
        ProductDAL objcontact = new ProductDAL();

        // GET: Contact
        public static List<Product> lstContact = new List<Product>();


        public ActionResult Index()
        {

            List<Product> lstContact = new List<Product>();
            lstContact = ProductDAL.GetAllProducts().ToList();
            return View(lstContact);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}