using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopCore.Enum;
using ShopCore.Helper;
using ShopData.Model;

namespace ShopWeb.Areas.Presentation.Controllers
{
    public class WishlistController : Controller
    {
        // GET: Presentation/Wishlist
        public ActionResult Index()
        {
            var wishlist = SessionHelper.GetSession<List<CartDetail>>(SessionName.Wishlist) ?? new List<CartDetail>();
            return View(wishlist);
        }

        [HttpPost]
        public ActionResult AddWishlist()
        {
            return null;
        }

        [HttpGet]
        public ActionResult RemoveItem(int id)
        {
            var wishlist = SessionHelper.GetSession<List<CartDetail>>(SessionName.Wishlist) ?? new List<CartDetail>();
            var firstOrDefault = wishlist.FirstOrDefault(x => x.ProductID == id);
            wishlist.Remove(firstOrDefault);
            return View("Index", wishlist);
        }

    }
}