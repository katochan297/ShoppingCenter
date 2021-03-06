﻿using System;
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
        private const int PageSize = 12;

        public MaskController()
        {
            SessionHelper.SetSession(SessionName.MenuActivity, "Mask");
        }
        
        // GET: Presentation/Mask
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            SessionHelper.SetSession(SessionName.MaskList, CacheManagement.Instance.ListMaskProduct.ToList());

            return IndexViewResult(page);
        }
        
        [HttpPost]
        public ActionResult Filter()
        {
            var cateFilter = Request[GlobalVariable.lstCategoryFilter + "[]"];
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

        [HttpGet]
        public ActionResult MaskDetail(int id)
        {
            List<MaskProduct> lstMask;
            MaskProduct mask;
            using (var uow = new ServiceUoW())
            {
                lstMask = uow.MaskProductRepository.GetRandom(6).ToList();
                mask = uow.MaskProductRepository.FindById(id);
            }
            ViewBag.ListMask = lstMask;
            return View(mask);
        }

        [NonAction]
        private ActionResult IndexViewResult(int page)
        {
            var lstMask = SessionHelper.GetSession<List<MaskProduct>>(SessionName.MaskList);

            ViewBag.ListMaskCategory = CacheManagement.Instance.ListMaskCategory;

            return Request.IsAjaxRequest()
               ? (ActionResult)PartialView("_MaskListPartial", lstMask.ToPagedList(page, PageSize))
               : View("Index", lstMask.ToPagedList(page, PageSize));
        }

    }
}