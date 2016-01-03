using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailLibrary;
using SecureCookie.Security;
using LoggerLibrary;


namespace MicroOptik.WebUI.Infrastructure.BasePages
{
    public abstract class BaseAdminController : Controller
    {
        public static void Successful(BaseAdminController controller, string mesaj)
        {
            controller.TempData["Successful"] = mesaj;
        }

        public static void Info(BaseAdminController controller, string mesaj)
        {
            controller.TempData["Info"] = mesaj;
        }

        public static void Alert(BaseAdminController controller, string mesaj)
        {
            controller.TempData["Alert"] = mesaj;
        }

        public static void Error(BaseAdminController controller, string mesaj)
        {
            controller.TempData["Error"] = mesaj;
            LogManager.SqlDB.Write("Admin", mesaj);
        }


        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.Cookies["MicroOptikAdmin"] != null)
            {
                HttpCookie cookie = requestContext.HttpContext.Request.Cookies["MicroOptikAdmin"];
                cookie = HttpSecureCookie.Decode(cookie);
                ViewData["Admin"] = cookie["yoneticiIsim"];
            }
            base.Initialize(requestContext);
        }


        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    LogManager.SqlDB.Write("Base Controller", filterContext.Exception);
        //    base.OnException(filterContext);
        //}


        protected override void HandleUnknownAction(string actionName)
        {
            LogManager.Event.Write("Admin Tanımsız İstek: " + actionName, " ");
            this.Redirect("~/Admin/Login/Index?action=" + actionName).ExecuteResult(this.ControllerContext);
        }

    }
}
