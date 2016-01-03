using System;
using System.ComponentModel;
using System.Web.Mvc;
using MicroOptik.WebUI.Infrastructure.Authorization;
using MicroOptik.WebUI.Infrastructure.BasePages;
using ModelLayer;

namespace MicroOptik.WebUI.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class HatalarController : BaseAdminController
    {
        private const int sayfaGosterim = 5;


        public ActionResult HataMesajlari([DefaultValue(0)] int Sayfa)
        {
            using (Database db = new Database())
            {
                var page = db.Page<HataMesaji>(Sayfa + 1, sayfaGosterim, "ORDER BY Tarih DESC");

                ViewData["sayfaGosterim"] = sayfaGosterim;
                ViewData["SayfaNo"] = Sayfa;
                ViewData["ToplamKayit"] = Convert.ToInt32(page.TotalItems);

                return View(page.Items);
            }
        }

        public ActionResult Delete()
        {
            using (Database db = new Database())
            {
                db.Execute("DELETE FROM HataMesaji");
                return RedirectToAction("HataMesajlari");
            }
        }
    }
}
