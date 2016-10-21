using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { Area = "Presentation" });
        }

        public ActionResult Error()
        {
            return RedirectToAction("Error", "Home", new { Area = "Presentation" });
        }

    }
}