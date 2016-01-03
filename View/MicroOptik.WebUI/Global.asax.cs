using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MicroOptik.WebUI.Infrastructure;
using MicroOptik.WebUI.Infrastructure.SiteCulture;
using Ninject;
using System.Reflection;
using ModelLayer;
using RepositoryLayer;

namespace MicroOptik.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }


        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            AreaRegistration.RegisterAllAreas();

            // Yeni alana
            routes.MapRoute(
             "Index",
             "index",
             new { controller = "Home", action = "Index" }
             );

            routes.MapRoute(
             "duyuru",
             "Duyurular",
             new { controller = "Content", action = "Announcement" }
             );

            routes.MapRoute(
             "Contact",
             "Iletisim",
             new { controller = "Content", action = "Contact" }
            );

            routes.MapRoute(
             "Brands",
             "Markalar",
             new { controller = "Content", action = "Brand" }
            );

            routes.MapRoute(
              "Products",
              "Urunler",
              new { controller = "Product", action = "Products" }
            );

            routes.MapRoute(
             "Error",
             "Error/{action}",
             new { controller = "Error", action = "ErrorPage" }
            );

            // Yönetim Panelinden Eklene Linkler
            routes.MapRoute(
            "hariciLink",
            "{action}",
            new { controller = "Content" }
            );



            // İçerik Varsayalan linkler
            routes.MapRoute(
              "PageContent",
              "{actName}/{icBaslikId}",
              new { controller = "Content", action = "PageContent" }
            );

            routes.MapRoute(
              "ProductList",
              "Urunler/{name}/{icBaslikId}",
              new { controller = "Product", action = "ProductList" }
            );

            routes.MapRoute(
             "ProductDetail",
             "UrunDetay/{name}/{icBaslikId}",
             new { controller = "Product", action = "ProductDetail" }
           );

            routes.MapRoute(
              "Search",
              "Urun/Arama/{searchKey}",
              new { controller = "Product", action = "ProductSearch" }
            );

         

            routes.MapRoute(
              "Default",
              "{controller}/{action}/{id}",
              new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
         
            foreach (Route r in routes)
            {
                if (!(r.RouteHandler is SingleCultureMvcRouteHandler))
                {
                    r.RouteHandler = new MultiCultureMvcRouteHandler();
                    r.Url = "{culture}/" + r.Url;

                    if (r.Defaults == null)
                    {
                        r.Defaults = new RouteValueDictionary();
                    }
                    r.Defaults.Add("culture", Culture.tr.ToString());

                    if (r.Constraints == null)
                    {
                        r.Constraints = new RouteValueDictionary();
                    }
                    r.Constraints.Add("culture", new CultureConstraint(Culture.en.ToString(),
         Culture.tr.ToString()));
                }
            }
        }

        public void SetupDependencyInjection()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IContactRepository>().To<ContactRepository>();
            kernel.Bind<IMailInfoRepository>().To<MailInfoRepository>();
            kernel.Bind<ILanguageRepository>().To<LanguageRepository>();
            kernel.Bind<IAnnouncementRepository>().To<AnnouncementRepository>();
            kernel.Bind<IImageRepository>().To<ImageRepository>();
            kernel.Bind<IContentTitleRepository>().To<ContentTitleRepository>();
            kernel.Bind<IContentRepository>().To<ContentRepository>();

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        protected void Application_Start()
        {
            this.SetupDependencyInjection();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

        }
    }
}