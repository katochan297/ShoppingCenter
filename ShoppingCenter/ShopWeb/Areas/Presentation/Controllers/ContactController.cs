using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopCore.Enum;
using ShopCore.Helper;

namespace ShopWeb.Areas.Presentation.Controllers
{
    public class ContactController : Controller
    {
        public ContactController()
        {
            SessionHelper.SetSession(SessionName.MenuActivity, "Contact");
        }

        // GET: Presentation/Contact
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}