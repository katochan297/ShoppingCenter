using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using ShopCore.Enum;
using ShopCore.Helper;
using ShopCore.Service;
using ShopData.Model;

namespace ShopWeb.Areas.Presentation.Controllers
{
    public class CartController : Controller
    {
        // GET: Presentation/Cart
        [HttpPost]
        public ActionResult AddCart()
        {
            var cart = new Cart();
            cart.Count = int.Parse(Request.Form[GlobalVariable.hidCount] ?? "0");
            cart.ProductID = int.Parse(Request.Form[GlobalVariable.hidProductId] ?? "0");
            Product product;
            using (var uow = new ServiceUoW())
            {
                product = uow.ProductRepository.FindById(cart.ProductID);
            }
            cart.Product = product;
            cart.Total = cart.Count * product.Price;

            AddToShoppingCart(cart);
            return PartialView("_CartPartial");
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RemoveCart(int id)
        {
            var shoppingCart = SessionHelper.GetSession<List<Cart>>(SessionName.ShoppingCart) ?? new List<Cart>();
            var firstOrDefault = shoppingCart.FirstOrDefault(x => x.ProductID == id);
            shoppingCart.Remove(firstOrDefault);
            return View("Index");
        }
        
        [NonAction]
        private void AddToShoppingCart(Cart cart)
        {
            var shoppingCart = SessionHelper.GetSession<List<Cart>>(SessionName.ShoppingCart);
            if (shoppingCart == null)
            {
                shoppingCart = new List<Cart>
                {
                    cart
                };
                SessionHelper.SetSession(SessionName.ShoppingCart, shoppingCart);
            }
            else
            {
                var oldCart = shoppingCart.FirstOrDefault(x => x.ProductID == cart.ProductID);
                if (oldCart != null)
                {
                    oldCart.Count += cart.Count;
                    if (oldCart.Count >= cart.Product.UnitOnOrder)
                    {
                        oldCart.Count = cart.Product.UnitOnOrder;
                        oldCart.IsOverOrder = true;
                    }
                    oldCart.Total = oldCart.Count * oldCart.Product.Price;
                }
                else
                {
                    shoppingCart.Add(cart);
                }
            }
        }
        
    }
}