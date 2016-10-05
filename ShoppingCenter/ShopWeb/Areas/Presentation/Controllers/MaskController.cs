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
        public JsonResult Filter()
        {
            var cateFilter = Request[GlobalVariable.ListCategoryFilter + "[]"];
            var html = @"
<div class='col-lg-4 col-md-3 col-sm-4'>
    <div class='product-hover'>
        <a href='@product_path'>
            <div class='image-product'>
                <img src='@product_pictureUrl' alt=''>
            </div>
            <div class='text-uppercase hover-description center'>
                <h4>@product_name</h4>
                <p>@product_price</p>
                <div class='boton-dark top-mini'>add to cart</div>
            </div>
         </a>
    </div>
</div>";

            if (cateFilter != null)
            {
                var lstCateId = new List<int>();
                foreach (var item in cateFilter.Split(','))
                {
                    int i;
                    int.TryParse(item, out i);
                    lstCateId.Add(i);
                }
                List<MaskProduct> lst;
                using (var uow = new ServiceUoW())
                {
                    lst = uow.MaskProductRepository.GetByListCategory(lstCateId.ToArray()).ToList();
                }



            }
            return Json(new { foo = "bar", baz = "Blech" });
        }


    }
}