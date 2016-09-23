using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopCore.Cache;
using ShopCore.Enum;
using ShopCore.Service;
using ShopData.Model;

namespace ShopWeb.Areas.Presentation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Presentation/Home
        public ActionResult Index()
        {
            var lstBanner = CacheManagement.Instance.ListBanner;

            var lstProduct = CacheManagement.Instance.ListProduct.OrderByDescending(x => x.OrderLevel).Take(8).ToList();

            ViewBag.ListBanner = lstBanner;
            ViewBag.ListProduct = lstProduct;
            Session[SessionName.MenuActivity] = 0;

            return View();
        }



    }
}