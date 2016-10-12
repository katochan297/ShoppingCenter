using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopWeb.Areas.Presentation.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Presentation/Checkout
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Confirm()
        {
            
        }

    }
}