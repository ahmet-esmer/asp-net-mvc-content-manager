using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroOptik.WebUI.Infrastructure.BasePages
{
    public abstract class BaseSiteController : Controller
    {

        public static void Successful(BaseSiteController controller, string mesaj)
        {
            controller.TempData["Successful"] = mesaj;
        }

        public static void Info(BaseSiteController controller, string mesaj)
        {
            controller.TempData["Info"] = mesaj;
        }

        public static void Alert(BaseSiteController controller, string mesaj)
        {
            controller.TempData["Alert"] = mesaj;
        }

        public static void Error(BaseSiteController controller, string mesaj)
        {
            controller.TempData["Error"] = mesaj;
        }

    }
}
