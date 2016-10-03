using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopCore.Enum;

namespace ShopWeb.Areas.Presentation.Controllers
{
    public class MaskController : Controller
    {
        // GET: Presentation/Mask
        public ActionResult Index()
        {
            Session[SessionName.MenuActivity] = ControllerContext.RouteData.Values["controller"].ToString();
            return View();
        }
    }
}