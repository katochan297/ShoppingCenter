using System;
using System.Collections.Generic;
using System.Data;
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
    public class MenuController : Controller
    {
        [ChildActionOnly]
        public PartialViewResult GetMenu()
        {
            var lst = CacheManagement.Instance.ListMenu.Where(x => x.ParentID == null).ToList();
            ViewBag.ListMenu = lst;
            return PartialView("_HeaderPartial");
        }
        

    }
}