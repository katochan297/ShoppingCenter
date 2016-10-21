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
    public class CheckoutController : Controller
    {
        // GET: Presentation/Checkout
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm(Order order)
        {
            var shoppingCart = SessionHelper.GetSession<Cart>(SessionName.ShoppingCart);
            if (shoppingCart != null)
            {
                order.CartID = shoppingCart.CartID;
                order.OrderDate = DateTime.Now.ToString("dd/MM/yyy HH:mm:ss");
                order.Status = DataStatus.Available;

                using (var uow = new ServiceUoW())
                {
                    uow.OrderRepository.Insert(order);
                    uow.CartRepository.Insert(shoppingCart);
                    foreach (var item in shoppingCart.CartDetails)
                    {
                        uow.CartDetailRepository.Insert(item);
                    }
                    uow.Commit();
                }
                SessionHelper.ClearSession();

                var msg = "Cám ơn quý khách đã đặt hàng.<br />Cửa hàng sẽ liên hệ với quý khách trong thời gian sớm nhất.";
                TempData[Alert.TempDataKey] = AlertHelper.Success(msg, true);
            }
            return View("Index");
        }

    }
}