using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopCore.Cache;
using ShopCore.Enum;
using ShopCore.Repository;
using ShopCore.Service;
using ShopData.Model;

namespace ShopWeb.Areas.Presentation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Presentation/Home
        public ActionResult Index()
        {
            //Mask test = new Mask();
            Product test = new Product();
            //test.MaskContent = "content1";
            //test.MaskSkinType = "skin type1";
            
            //Product test1 = new Product();
            test.Description = "des1";
            test.ProductSKU = "sku1";
            test.Quantity = 1;
            test.Price = 1000;
            test.UnitOnOrder = 1;
            test.OrderLevel = 1;
            test.PictureUrl = "url1";
            test.Status = 1;

            using (var v = new ServiceUoW())
            {
                //v.ProductRepository.Insert(test);
                
                //v.Commit();

                
                ShoppingCenterContext ctx = new ShoppingCenterContext();
                ctx.Products.Add(test);
                ctx.SaveChanges();


            }

            var lstBanner = CacheManagement.Instance.ListBanner;

            var lstProduct = CacheManagement.Instance.ListProduct.OrderByDescending(x => x.OrderLevel).Take(8).ToList();

            ViewBag.ListBanner = lstBanner;
            ViewBag.ListProduct = lstProduct;

            Session[SessionName.MenuActivity] = ControllerContext.RouteData.Values["controller"].ToString();
            
            return View();
        }



    }
}