using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopCore.Enum;
using ShopCore.Service;
using ShopWeb.Areas.Presentation.Models;

namespace ShopWeb.Areas.Presentation.Controllers
{
    public class MenuController : Controller
    {
        [ChildActionOnly]
        public async Task<PartialViewResult> GetMenu()
        {

            return PartialView("_HeaderPartial");
        }


        [ChildActionOnly]
        public async Task<PartialViewResult> GetMenu2()
        {
            List<MenuModel> lst = new List<MenuModel>
            {
                new MenuModel {Title = "Home", Path = Url.Action("Index","Home"), Activated = MenuActivated.Home},
                new MenuModel {Title = "Shop", ListCatalog = await GetListMenuCatalog(), Activated = MenuActivated.Shop},
                new MenuModel {Title = "About", Activated = MenuActivated.About},
                new MenuModel {Title = "Contact", Activated = MenuActivated.Contact}
            };
            ViewBag.ListMenu = lst;
            return PartialView("_HeaderPartial");
        }

        private async Task<List<MenuCatalog>> GetListMenuCatalog()
        {
            CategoryService categorySvc = new CategoryService();
            SubcategoryService subcategorySvc = new SubcategoryService();

            var lst = new List<MenuCatalog>();
            var lstCategory = await categorySvc.GetListCategory();
            foreach (var item in lstCategory)
            {
                var obj = new MenuCatalog
                {
                    Category = item,
                    ListSubcategory = await subcategorySvc.GetListSubcategoryByParent(item.CategoryID)
                };
                lst.Add(obj);
            }
            return lst;
        }

    }
}