using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ShopWeb.Areas.Administrator.Models
{
    public class AccountViewModel
    {
        public class LogInViewModel
        {
            [Required]
            [DataType(DataType.Text)]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [HiddenInput]
            public string ReturnUrl { get; set; }

        }


        public class AppUser : ClaimsPrincipal
        {
            public AppUser(ClaimsPrincipal principal) : base(principal)
            {
            }

            public string Name => FindFirst(ClaimTypes.Name).Value;
        }

    }
}