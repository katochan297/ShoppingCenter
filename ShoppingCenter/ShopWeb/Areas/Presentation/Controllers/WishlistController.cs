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
            var quantity = int.Parse(Request.Form[GlobalVariable.hidCount] ?? "0");
            var productId = int.Parse(Request.Form[GlobalVariable.hidProductId] ?? "0");
            var product = CacheManagement.Instance.ListProduct.FirstOrDefault(x => x.ProductID == productId);

            var wishlist = SessionHelper.GetSession<List<CartDetail>>(SessionName.Wishlist);

            if (wishlist == null)
            {
                CreateWishlist(quantity, product);
            }
            else
            {
                UpdateWishlist(quantity, product, wishlist);
            }

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
        private void CreateWishlist(int quantity, Product product)
        {
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
        private void UpdateWishlist(int quantity, Product product, List<CartDetail> wishlist)
        {
            var cartDetail = wishlist.FirstOrDefault(x => x.ProductID == product.ProductID);
            if (cartDetail != null)
            {
                cartDetail.Quantity += quantity;
                if (cartDetail.Quantity >= product.UnitOnOrder)
                {
                    cartDetail.Quantity = product.UnitOnOrder;
                }
                cartDetail.TotalUnitPrice = cartDetail.Quantity * product.Price;
            }
            else
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