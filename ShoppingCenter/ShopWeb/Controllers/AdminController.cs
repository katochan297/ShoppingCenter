using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using ShopWeb.Areas.Administrator.Models;

namespace ShopWeb.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public AccountViewModel.AppUser CurrentUser
        {
            get
            {
                return new AccountViewModel.AppUser(this.User as ClaimsPrincipal);
            }
        }

    }
}