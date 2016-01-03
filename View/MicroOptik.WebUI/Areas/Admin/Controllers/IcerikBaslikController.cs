using System;
using System.Web.Mvc;
using ModelLayer;
using MicroOptik.WebUI.Content.HtmlHelpers;
using MicroOptik.WebUI.Infrastructure.BasePages;
using MicroOptik.WebUI.Infrastructure.Authorization;

namespace MicroOptik.WebUI.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class IcerikBaslikController : BaseAdminController
    {
        private IContentTitleRepository  _contentTitleRepository;
        private ILanguageRepository _languageRepository;

        public IcerikBaslikController(IContentTitleRepository contentTitleRepository,
            ILanguageRepository languageRepository)
        {
            this._contentTitleRepository = contentTitleRepository;
            this._languageRepository = languageRepository;
        }


        public ActionResult Index(string dil)
        {

            SiteDileri();
            return View(_contentTitleRepository.FindAll(dil));
        }

        public ActionResult Create()
        {
            KategoriDropDownList();
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(IcerikBaslik icBaslik)
        {
            int sonId = 0;
            try
            { 
            sonId = _contentTitleRepository.Insert(icBaslik);
            }
            catch (Exception ex)
            {
                Error(this, ex.ToString());
            }

            Successful(this, "Sayfa başlığı başarı ile oluşturdu. ilgili dilde sayfa içerigini oluşturunuz. ");
            return RedirectToAction("Index", "IcerikBaslik", new { dil = "tr" });
        }

        public ActionResult Delete(string serial, string dil)
        {
            try
            {
                _contentTitleRepository.Delete(serial);
            }
            catch (Exception ex)
            {
                Error(this, ex.ToString());
            }

            return RedirectToAction("Index", "IcerikBaslik", new { dil= dil });
        }

        public ActionResult Durum(string serial, Boolean durum, string dil)
        {
            try
            {
                _contentTitleRepository.State(serial, durum);
            }
            catch (Exception ex)
            {
                Error(this, ex.ToString());
            }

            return RedirectToAction("Index", "IcerikBaslik", new { dil = dil });
        }

        public ActionResult Edit(int id)
        {
            KategoriDropDownList();

            IcerikBaslik ice = _contentTitleRepository.FindById(id);
                
            return View(ice);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(IcerikBaslik iceBaslik)
        {
            try
            {
                _contentTitleRepository.Insert(iceBaslik);
                Successful(this, "Kayıt başarı ile güncellendi.");
            }
            catch (Exception ex)
            {
                Error(this, ex.ToString());
            }

            return RedirectToAction("Index", "IcerikBaslik", new { dil = "tr" });
        }

        public JsonResult Siralama(int id, int sira)
        {
            try
            {
                _contentTitleRepository.Siralama(id, sira);
            }
            catch (Exception ex)
            {
                return Json(new {success=true, message=AjaxMesaj.Successful(ex.ToString()) });
            }
            return Json(new {success=true, message=AjaxMesaj.Successful("Siralama işlemi başarı ile yapıldı.") });
        }

        private void KategoriDropDownList()
        {
            ViewData["Kategori"] = _contentTitleRepository.FindDropDownList();
        }

        private void SiteDileri()
        {
            ViewData["SiteDil"] = _languageRepository.FindAll();
        }
    }
}
