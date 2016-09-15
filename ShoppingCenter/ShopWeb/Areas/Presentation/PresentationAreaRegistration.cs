using System.Web.Mvc;

namespace ShopWeb.Areas.Presentation
{
    public class PresentationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Presentation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Presentation_default",
                "Presentation/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ShopWeb.Areas.Presentation.Controllers" }
            );
        }
    }
}