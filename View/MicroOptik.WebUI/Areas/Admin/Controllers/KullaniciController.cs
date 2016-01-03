using System.Web.Mvc;
using MicroOptik.WebUI.Infrastructure.Authorization;
using MicroOptik.WebUI.Infrastructure.BasePages;
using ModelLayer;

namespace MicroOptik.WebUI.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class KullaniciController : BaseAdminController
    {
        private IUserRepository _userRepostory;

        public KullaniciController(IUserRepository userRepostory)
        {
            this._userRepostory = userRepostory;
        }

        public ActionResult Index()
        {
            return View( _userRepostory.FindAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult KullaniciKaydet(Kullanici k)
        {
            if (ModelState.IsValid)
            {
                _userRepostory.Insert(k);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Lütfen kullanıcı bilgilerinizi kontrol ediniz.");
            }

            return View(k);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Delete(int KullaniciId)
        {
            _userRepostory.Delete(KullaniciId);
            return RedirectToAction("Index");
        }
    }
}
