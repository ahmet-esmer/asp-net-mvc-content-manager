using System;
using System.Web;
using System.Web.Mvc;
using MicroOptik.WebUI.Infrastructure.BasePages;
using MicroOptik.WebUI.Models;
using ModelLayer;
using SecureCookie.Security;


namespace MicroOptik.WebUI.Areas.Admin.Controllers
{

    public class LoginController : BaseAdminController
    {
        private IUserRepository _kullaniciRepostory;

        public LoginController(IUserRepository kullaniciRepostory)
        {
            this._kullaniciRepostory = kullaniciRepostory;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(Login admin)
        {
            if (ModelState.IsValid)
            {
                var _admin = _kullaniciRepostory.Login(admin.EPosta, admin.Sifre);

                if (_admin != null)
                {
                    HttpCookie yonetici = new HttpCookie("MicroOptikAdmin");
                    yonetici.Values.Add("yoneticiId", _admin.Id.ToString());
                    yonetici.Values.Add("yoneticiIsim", _admin.AdiSoyadi);
                    Response.Cookies.Add(HttpSecureCookie.Encode(yonetici));
                    return RedirectToAction("Index", "Arayuz");
                }
                else
                {
                    ModelState.AddModelError("", "Lütfen kullanıcı bilgilerinizi kontrol ediniz.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Lütfen kullanıcı bilgilerinizi kontrol ediniz.");
            }

            return View();
        }

        public ActionResult Cikis()
        {
            if (Request.Cookies["MicroOptikAdmin"] != null)
                Response.Cookies["MicroOptikAdmin"].Expires = DateTime.Now.AddDays(-1);

            return RedirectToAction("Index", "Arayuz");
        }
    }
}
