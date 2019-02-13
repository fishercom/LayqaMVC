using System.Web.Mvc;

namespace Layqa.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            /*
            context.MapRoute(
                name: "Admin_CMS",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new { controller = "Article", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Layqa.Web.Areas.Admin.Controllers" }
            );
            */
            context.MapRoute(
                name: "Admin_default",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Layqa.Web.Areas.Admin.Controllers" }
            );
        }
    }
}