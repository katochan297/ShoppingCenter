using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ShopCore.Cache;
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
        [ValidateAntiForgeryToken]
        public ActionResult AddCart()
        {
            var quantity = int.Parse(Request.Form[GlobalVariable.hidCount] ?? "0");
            var productId = int.Parse(Request.Form[GlobalVariable.hidProductId] ?? "0");
            var product = CacheManagement.Instance.ListProduct.FirstOrDefault(x => x.ProductID == productId);
           
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
            var shoppingCart = SessionHelper.GetSession<Cart>(SessionName.ShoppingCart);
            var firstOrDefault = shoppingCart.CartDetails.FirstOrDefault(x => x.ProductID == id);
            shoppingCart.CartDetails.Remove(firstOrDefault);
            return View("Index", shoppingCart);
        }
        
        [NonAction]
        private void CreateCart(int quantity, Product product)
        {
            var total = quantity * product.Price;
            var id = Guid.NewGuid().ToString();
            var cart = new Cart
            {
                CartID = id,
                TotalPrice = total,
                Status = DataStatus.Available,
                CartDetails = new List<CartDetail>
                {
                    new CartDetail{
                        CartID = id,
                        ProductID = product.ProductID,
                        Quantity = quantity,
                        TotalUnitPrice = total,
                        Product = product
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
                    CartID = shoppingCart.CartID,
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