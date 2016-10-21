using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using ShopWeb.Areas.Administrator.Models;
using ShopWeb.Controllers;

namespace ShopWeb.Areas.Administrator.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Administrator/Account
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new AccountViewModel.LogInViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult LogIn(AccountViewModel.LogInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Don't do this in production!
            if (model.Username == "admin" && model.Password == "1")
            {
                var identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, "Ben"),
                        new Claim(ClaimTypes.Email, "a@b.com"),
                        new Claim(ClaimTypes.Country, "England")
                    },
                    "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            // user authN failed
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }

        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }


    }
}