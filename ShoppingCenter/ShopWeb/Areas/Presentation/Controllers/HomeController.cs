using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopCore.Cache;
using ShopCore.Enum;
using ShopCore.Helper;
using ShopCore.Repository;
using ShopCore.Service;
using ShopData.Model;

namespace ShopWeb.Areas.Presentation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Presentation/Home
        [HttpGet]
        public ActionResult Index()
        {
            var lstBanner = CacheManagement.Instance.ListBanner;

            List<MaskProduct> lstMask;
            using (var uow = new ServiceUoW())
            {
                lstMask = uow.MaskProductRepository.GetOrderbyLevel(8).ToList();
            }

            ViewBag.ListBanner = lstBanner;
            ViewBag.ListMask = lstMask;
            
            SessionHelper.SetSession(SessionName.MenuActivity, ControllerContext.RouteData.Values["controller"].ToString());
            
            return View();
        }



    }
}