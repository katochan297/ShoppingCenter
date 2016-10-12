using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            var quantity = int.Parse(Request.Form[GlobalVariable.hidCount] ?? "0");
            var productId = int.Parse(Request.Form[GlobalVariable.hidProductId] ?? "0");
            Product product;
            using (var uow = new ServiceUoW())
            {
                product = uow.ProductRepository.FindById(productId);
            }

            var shoppingCart = SessionHelper.GetSession<Cart>(SessionName.ShoppingCart);

            if (shoppingCart == null)
            {
                CreateCart(quantity, product);
            }
            else
            {
                UpdateCart(quantity, product, shoppingCart);
            }
            
            return PartialView("_CartPartial");
        }

        [HttpGet]
        public ActionResult Index()
        {
            var shoppingCart = SessionHelper.GetSession<Cart>(SessionName.ShoppingCart) ?? new Cart();
            return View(shoppingCart);
        }

        [HttpGet]
        public ActionResult RemoveCartItem(int id)
        {
            var shoppingCart = SessionHelper.GetSession<Cart>(SessionName.ShoppingCart) ?? new Cart();
            var firstOrDefault = shoppingCart.CartDetails.FirstOrDefault(x => x.ProductID == id);
            shoppingCart.CartDetails.Remove(firstOrDefault);
            return View("Index", shoppingCart);
        }
        
        [NonAction]
        private void CreateCart(int quantity, Product product)
        {
            var total = quantity * product.Price;
            var cart = new Cart
            {
                TotalPrice = total,
                CartDetails = new List<CartDetail>
                {
                    new CartDetail{
                        ProductID = product.ProductID,
                        Quantity = quantity,
                        Product = product,
                        TotalUnitPrice = total
                    }
                }
            };
            SessionHelper.SetSession(SessionName.ShoppingCart, cart);
        }

        [NonAction]
        private void UpdateCart(int quantity, Product product, Cart shoppingCart)
        {
            var cartDetail = shoppingCart.CartDetails.FirstOrDefault(x => x.ProductID == product.ProductID);
            if (cartDetail != null)
            {
                cartDetail.Quantity += quantity;
                if (cartDetail.Quantity >= product.UnitOnOrder)
                {
                    cartDetail.Quantity = product.UnitOnOrder;
                    cartDetail.IsOverOrder = true;
                }
                cartDetail.TotalUnitPrice = cartDetail.Quantity * product.Price;
            }
            else
            {
                shoppingCart.CartDetails.Add(new CartDetail
                {
                    ProductID = product.ProductID,
                    Quantity = quantity,
                    Product = product,
                    TotalUnitPrice = quantity * product.Price
                });
            }

            shoppingCart.TotalPrice = shoppingCart.CartDetails.Select(x => x.TotalUnitPrice).Sum();
        }
        
    }
}