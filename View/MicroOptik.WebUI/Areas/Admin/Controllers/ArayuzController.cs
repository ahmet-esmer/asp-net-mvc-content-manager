using System.Web.Mvc;
using MicroOptik.WebUI.Infrastructure.Authorization;
using MicroOptik.WebUI.Infrastructure.BasePages;

namespace MicroOptik.WebUI.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ArayuzController : BaseAdminController
    {
        public ActionResult Index()
        {
            //Successful(this, "Succesful Mesaj");
            //Error(this, "Error Mesaj");
            //Alert(this, "Alert Mesaj");
            //Info(this, "Info Mesaj");

            return View();
        }

    }
}
