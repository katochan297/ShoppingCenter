using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopCore.Cache;
using ShopCore.Enum;
using ShopCore.Service;
using ShopData.Model;
using PagedList;

namespace ShopWeb.Areas.Presentation.Controllers
{
    public class MaskController : Controller
    {
        private const int PageSize = 3;

        // GET: Presentation/Mask
        public ActionResult Index(int page = 1)
        {
            var lstMask = CacheManagement.Instance.ListMaskProduct;
            var lstMaskCategory = CacheManagement.Instance.ListMaskCategory;
            
            ViewBag.ListMaskCategory = lstMaskCategory;

            Session[SessionName.MenuActivity] = ControllerContext.RouteData.Values["controller"].ToString();
            
            //return View(lstMask.ToPagedList(page, PageSize));

            return Request.IsAjaxRequest()
               ? (ActionResult)PartialView("_MaskListPartial", lstMask.ToPagedList(page, PageSize))
               : View(lstMask.ToPagedList(page, PageSize));
        }

     
        public ActionResult Filter()
        {
            var cateFilter = Request[GlobalVariable.ListCategoryFilter + "[]"];
            var html = string.Empty;
            List<MaskProduct> lst = new List<MaskProduct>();

            if (cateFilter != null)
            {
                var lstCateId = new List<int>();
                foreach (var item in cateFilter.Split(','))
                {
                    int i;
                    int.TryParse(item, out i);
                    lstCateId.Add(i);
                }
                
                using (var uow = new ServiceUoW())
                {
                    lst = uow.MaskProductRepository.GetByListCategory(lstCateId.ToArray()).ToList();
                }


                foreach (var item in lst)
                {
                    html += @"
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
                    html = html.Replace("@product_path", "");
                }

            }


            //return Json(new {html});

            //return Json(new { foo = "bar", baz = "Blech" });
            return Index();

            return Request.IsAjaxRequest()
               ? (ActionResult)PartialView("_MaskListPartial", lst.ToPagedList(1, PageSize))
               : View("Index",lst.ToPagedList(1, PageSize));

        }


    }
}