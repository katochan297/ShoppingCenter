using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopCore.Cache;
using ShopCore.Enum;
using ShopCore.Service;
using ShopData.Model;

namespace ShopWeb.Areas.Presentation.Controllers
{
    public class MaskController : Controller
    {
        // GET: Presentation/Mask
        public ActionResult Index()
        {
            var lstMask = CacheManagement.Instance.ListMaskProduct;
            var lstMaskCategory = CacheManagement.Instance.ListMaskCategory;
            
            ViewBag.ListMask = lstMask;
            ViewBag.ListMaskCategory = lstMaskCategory;

            Session[SessionName.MenuActivity] = ControllerContext.RouteData.Values["controller"].ToString();
            return View();
        }

        [HttpPost]
        public void Filter()
        {
            var lstCateId = new List<int>();
            foreach (var item in Request[GlobalVariable.ListCategoryFilter + "[]"].Split(','))
            {
                int i;
                int.TryParse(item, out i);
                lstCateId.Add(i);
            }
            List<MaskProduct> lst = new List<MaskProduct>();
            using (var uow = new ServiceUoW())
            {
                lst = uow.MaskProductRepository.GetByListCategory(lstCateId.ToArray()).ToList();
            }

            ViewBag.ListMask = lst;
        }


    }
}