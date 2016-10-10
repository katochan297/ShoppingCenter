using System;
using System.Collections.Generic;
using System.Linq;
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
        public void AddCart()
        {
            var shoppingCart = SessionHelper.GetSession<List<Cart>>(SessionName.ShoppingCart);
            if (shoppingCart == null)
            {
                Cart cart = new Cart();
                cart.Count = int.Parse(Request.Form[GlobalVariable.hidCount]);
                var productId = int.Parse(Request.Form[GlobalVariable.hidProductId]);
                Product product;
                using (var uow = new ServiceUoW())
                {
                    product = uow.ProductRepository.FindById(productId);
                }
                cart.Products.Add(product);
                cart.Total = cart.Count * product.Price;

            }

        }
        

    }
}