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
using ShopCore.Helper;

namespace ShopWeb.Areas.Presentation.Controllers
{
    public class MaskController : Controller
    {
        private const int PageSize = 3;

        [NonAction]
        private ActionResult IndexViewResult(int page)
        {
            var lstMask = SessionHelper.GetSession<List<MaskProduct>>(SessionName.MaskList);           
            SessionHelper.SetSession(SessionName.MenuActivity, ControllerContext.RouteData.Values["controller"].ToString());

            ViewBag.ListMaskCategory = CacheManagement.Instance.ListMaskCategory;

            return Request.IsAjaxRequest()
               ? (ActionResult)PartialView("_MaskListPartial", lstMask.ToPagedList(page, PageSize))
               : View("Index", lstMask.ToPagedList(page, PageSize));
        }

        // GET: Presentation/Mask
        public ActionResult Index(int page = 1)
        {
            var lstMask = SessionHelper.GetSession<List<MaskProduct>>(SessionName.MaskList);
            if (lstMask == null)
                SessionHelper.SetSession(SessionName.MaskList,
                    CacheManagement.Instance.ListMaskProduct.ToList());

            return IndexViewResult(page);
        }
        
        [HttpPost]
        public ActionResult Filter()
        {
            var cateFilter = Request[GlobalVariable.ListCategoryFilter + "[]"];
            if (cateFilter != null)
            {
                var lstCateId = new List<int>();
                foreach (var item in cateFilter.Split(','))
                {
                    int i;
                    int.TryParse(item, out i);
                    lstCateId.Add(i);
                }

                List<MaskProduct> lstMask;
                using (var uow = new ServiceUoW())
                {
                    lstMask = uow.MaskProductRepository.GetByListCategory(lstCateId.ToArray()).ToList();
                }
               
                return Request.IsAjaxRequest()
                    ? (ActionResult) PartialView("_MaskListPartial", lstMask.ToPagedList(1, PageSize))
                    : View("Index", lstMask.ToPagedList(1, PageSize));
            }
            else
            {
                return Index();
            }
        }

        [HttpGet]
        public ActionResult Category(int id = 0)
        {
            List<MaskProduct> lstMask;
            using (var uow = new ServiceUoW())
            {
                lstMask = uow.MaskProductRepository.GetByCategory(id).ToList();
            }
            SessionHelper.SetSession(SessionName.MaskList, lstMask);

            ViewBag.CategoryId = id;

            return IndexViewResult(1);
        }

        public ActionResult MaskDetail(int id)
        {
            List<MaskProduct> lstMask;
            MaskProduct mask;
            using (var uow = new ServiceUoW())
            {
                lstMask = uow.MaskProductRepository.GetOrderbyLevel(8).ToList();
                mask = uow.MaskProductRepository.FindById(id);
            }
            ViewBag.ListMask = lstMask;
            return View(mask);
        }

    }
}