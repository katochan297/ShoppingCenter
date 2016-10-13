using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopCore.Enum;
using ShopCore.Helper;

namespace ShopWeb.Areas.Presentation.Controllers
{
    public class AboutController : Controller
    {
        public AboutController()
        {
            SessionHelper.SetSession(SessionName.MenuActivity, "About");
        }

        // GET: Presentation/About
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}