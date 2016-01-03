using System.Web.Mvc;
using MicroOptik.WebUI.Infrastructure;
using MicroOptik.WebUI.Infrastructure.SiteCulture;

namespace MicroOptik.WebUI.Areas.Admin
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
            context.MapRoute(
                "AdminDefault",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            ).RouteHandler = new SingleCultureMvcRouteHandler();

            context.MapRoute(
                "Login",
                "Login",
                new { controller = "Login", action = "Index" }
                ).RouteHandler = new SingleCultureMvcRouteHandler();

      


             context.MapRoute(
                "AdminLogin",
                "Admin/",
                new { controller = "Login", action = "Index"  }
            ).RouteHandler = new SingleCultureMvcRouteHandler();

           
        }
    }
}
