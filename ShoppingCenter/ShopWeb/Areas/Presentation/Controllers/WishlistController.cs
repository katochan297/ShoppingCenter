using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopCore.Cache;
using ShopCore.Enum;
using ShopCore.Helper;
using ShopData.Model;

namespace ShopWeb.Areas.Presentation.Controllers
{
    public class WishlistController : Controller
    {
        // GET: Presentation/Wishlist
        [HttpGet]
        public ActionResult Index()
        {
            var wishlist = SessionHelper.GetSession<List<CartDetail>>(SessionName.Wishlist) ?? new List<CartDetail>();
            return View(wishlist);
        }

        [HttpPost]
        public ActionResult AddWishlist()
        {
            //var quantity = int.Parse(Request.Form[GlobalVariable.hidCount] ?? "0");
            var productId = int.Parse(Request.Form[GlobalVariable.hidProductId] ?? "0");
            var product = CacheManagement.Instance.ListProduct.FirstOrDefault(x => x.ProductID == productId);

            if (product != null)
                ManageWishlist(product);

            return PartialView("_WishlistPartial");
        }

        [HttpGet]
        public ActionResult RemoveItem(int id)
        {
            var wishlist = SessionHelper.GetSession<List<CartDetail>>(SessionName.Wishlist) ?? new List<CartDetail>();
            var firstOrDefault = wishlist.FirstOrDefault(x => x.ProductID == id);
            wishlist.Remove(firstOrDefault);
            return View("Index", wishlist);
        }

        [NonAction]
        private void ManageWishlist(Product product)
        {
            var wishlist = SessionHelper.GetSession<List<CartDetail>>(SessionName.Wishlist);
            if (wishlist == null)
            {
                CreateWishlist(product);
            }
            else
            {
                UpdateWishlist(product, wishlist);
            }
        }

        [NonAction]
        private void CreateWishlist(Product product)
        {
            const int quantity = 1;
            var total = quantity * product.Price;
            var wishlist = new List<CartDetail>
            {
                new CartDetail
                {
                    ProductID = product.ProductID,
                    Quantity = quantity,
                    TotalUnitPrice = total,
                    Product = product
                }
            };
            SessionHelper.SetSession(SessionName.Wishlist, wishlist);
        }

        [NonAction]
        private void UpdateWishlist(Product product, List<CartDetail> wishlist)
        {
            const int quantity = 1;
            var cartDetail = wishlist.FirstOrDefault(x => x.ProductID == product.ProductID);
            if (cartDetail == null)
            {
                wishlist.Add(new CartDetail
                {
                    ProductID = product.ProductID,
                    Quantity = quantity,
                    Product = product,
                    TotalUnitPrice = quantity * product.Price
                });
            }
        }

    }
}