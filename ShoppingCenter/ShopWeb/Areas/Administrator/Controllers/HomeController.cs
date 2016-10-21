using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopWeb.Controllers;

namespace ShopWeb.Areas.Administrator.Controllers
{
    public class HomeController : AdminController
    {
        // GET: Administrator/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}