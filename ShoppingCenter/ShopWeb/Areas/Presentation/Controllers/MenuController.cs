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
            List<Menu> lstMenu;
            using (var uow = new ServiceUoW())
            {
                lstMenu = uow.MenuRepository.GetMenuParent().ToList();
            }
            return PartialView("_HeaderPartial", lstMenu);
        }
        

    }
}