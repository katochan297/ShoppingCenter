using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ShopCore.Cache;
using ShopData.Model;

namespace ShopWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            //Load Cache
            CacheManagement.Instance.Init();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Error");
        }


    }
}
