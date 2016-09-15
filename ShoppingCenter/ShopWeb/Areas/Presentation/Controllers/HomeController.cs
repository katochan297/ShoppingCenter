using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopCore.Enum;
using ShopCore.Service;
using ShopData.Model;

namespace ShopWeb.Areas.Presentation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Presentation/Home
        public async Task<ActionResult> Index()
        {
            BannerService bannerSvc = new BannerService();
            List<Banner> lstBanner = await bannerSvc.GetListBanner();
            
            ProductService productSvc = new ProductService();
            List<Product> lstProduct = await productSvc.GetListProductLevel(8);

            ViewBag.ListBanner = lstBanner;
            ViewBag.ListProduct = lstProduct;
            Session[SessionName.MenuActivity] = MenuActivated.Home;

            return View();
        }

        

    }
}