using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using ShopData.Model;
using ShopWeb.Areas.Administrator.Models;

namespace ShopWeb.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public ApplicationUser CurrentUser
        {
            get
            {
                return new ApplicationUser();
            }
        }

    }
}