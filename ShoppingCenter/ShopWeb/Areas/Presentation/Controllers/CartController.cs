using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult AddCart()
        {
            var quantity = int.Parse(Request.Form[GlobalVariable.hidCount] ?? "0");
            var productId = int.Parse(Request.Form[GlobalVariable.hidProductId] ?? "0");
            var product = CacheManagement.Instance.ListProduct.FirstOrDefault(x => x.ProductID == productId);

            CreateShoppingCart(quantity, product);
            
            return PartialView("_CartPartial");
        }

        [HttpGet]
        public ActionResult AddCartByWishlist(int id)
        {
            var wishlist = SessionHelper.GetSession<List<CartDetail>>(SessionName.Wishlist);
            var product =  wishlist?.FirstOrDefault(x => x.ProductID == id);
            if (product != null)
            {
                wishlist.Remove(product);
                CreateShoppingCart(product.Quantity, product.Product);
            }

            return RedirectToAction("Index", "Wishlist");
        }

        [HttpPost]
        public ActionResult AddCartQuickly()
        {
            var productId = int.Parse(Request.Form[GlobalVariable.hidProductId] ?? "0");
            var product = CacheManagement.Instance.ListProduct.FirstOrDefault(x => x.ProductID == productId);
            if (product != null)
            {
                CreateShoppingCart(1, product);
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

        [HttpPost]
        public ActionResult ChangeQuantity()
        {
            string json;
            using (var reader = new StreamReader(Request.InputStream))
            {
                json = reader.ReadToEnd();
            }
            var data = System.Web.Helpers.Json.Decode(json);

            var shoppingCart = SessionHelper.GetSession<Cart>(SessionName.ShoppingCart);
            if (shoppingCart != null)
            {
                int qty = int.Parse(data["Quantity"].ToString());
                int pid = int.Parse(data["ProductID"].ToString());
                var product = shoppingCart.CartDetails.FirstOrDefault(x => x.ProductID == pid);
                if (product != null)
                    UpdateCart(qty, product.Product, shoppingCart);
            }
            //TODO
            return PartialView("_CartDetailPartial", shoppingCart);
        }

        [NonAction]
        private void CreateShoppingCart(int quantity, Product product)
        {
            var shoppingCart = SessionHelper.GetSession<Cart>(SessionName.ShoppingCart);
            if (shoppingCart == null)
            {
                CreateCart(quantity, product);
            }
            else
            {
                UpdateCart(quantity, product, shoppingCart);
            }
        }


        [NonAction]
        private void CreateCart(int quantity, Product product)
        {
            if (quantity > 0 && quantity <= product.UnitOnOrder)
            {
                var total = quantity*product.Price;
                var id = Guid.NewGuid().ToString();
                var cart = new Cart
                {
                    CartID = id,
                    TotalPrice = total,
                    Status = DataStatus.Available,
                    CartDetails = new List<CartDetail>
                    {
                        new CartDetail
                        {
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
                else if (cartDetail.Quantity < 1)
                {
                    cartDetail.Quantity = 1;
                }
                cartDetail.TotalUnitPrice = cartDetail.Quantity * product.Price;
            }
            else
            {
                if (quantity > 0 && quantity <= product.UnitOnOrder)
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
            }
            shoppingCart.TotalPrice = shoppingCart.CartDetails.Select(x => x.TotalUnitPrice).Sum();
        }
        
    }
}