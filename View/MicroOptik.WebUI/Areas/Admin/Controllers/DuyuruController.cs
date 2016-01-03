using System;
using System.Web.Mvc;
using MicroOptik.WebUI.Infrastructure.Authorization;
using MicroOptik.WebUI.Infrastructure.BasePages;
using ModelLayer;

namespace MicroOptik.WebUI.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class DuyuruController : BaseAdminController
    {
        private IAnnouncementRepository _announcementRepository;
        private ILanguageRepository _languageRepository;

        public DuyuruController(IAnnouncementRepository announcementRepository, ILanguageRepository _languageRepository)
        {
            this._announcementRepository = announcementRepository;
            this._languageRepository = _languageRepository;
        }

        public ActionResult Duyurular()
        {
            return View(_announcementRepository.FindAll());
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _announcementRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Error(this, ex.ToString());
            }

            return RedirectToAction("Duyurular");
        }

        public ActionResult Durum(int id, Boolean durum)
        {
            try
            {
                _announcementRepository.State(id, durum);
            }
            catch(Exception ex)
            {
                Error(this, ex.ToString());
            }

            return RedirectToAction("Duyurular");
        }

        public ActionResult Create()
        {
            SiteDileri();
            return View();
        } 

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Duyuru duyuru)
        {
            try
            {
                _announcementRepository.Insert(duyuru);
                Successful(this, "Duyuru kaydı başarı ile oluştulurdu.");
                return RedirectToAction("Duyurular");
            }
            catch(Exception ex)
            {
                Error(this, ex.ToString());
                SiteDileri();
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            SiteDileri();
            return View(_announcementRepository.FindById(id));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Duyuru duyuru )
        {
            try
            {
                _announcementRepository.Update(duyuru);
                Successful(this, "Kayıt başarı ile güncellendi.");
            }
            catch(Exception ex)
            {
                
                Error(this, ex.ToString());
            }

            return RedirectToAction("Duyurular");
        }

        private void SiteDileri()
        {
            ViewData["SiteDil"] = _languageRepository.FindAll();
        }

    }
}
