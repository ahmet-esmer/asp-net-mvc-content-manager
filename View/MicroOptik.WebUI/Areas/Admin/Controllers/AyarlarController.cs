using System;
using System.Web.Mvc;
using BusinessLayer;
using MicroOptik.WebUI.Infrastructure.Authorization;
using MicroOptik.WebUI.Infrastructure.BasePages;
using ModelLayer;

namespace MicroOptik.WebUI.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class AyarlarController : BaseAdminController
    {
        private IContactRepository _contactRepository;
        private IMailInfoRepository _mailInfoRepository;

        public AyarlarController (IContactRepository contactRepository,
                                  IMailInfoRepository  mailInfoRepository )
	    {
            this._contactRepository = contactRepository;
            this._mailInfoRepository = mailInfoRepository;
	    }
 
        public ActionResult Genel()
        {
            return View();
        }

        public PartialViewResult SiteIletisim()
        {
            SiteIletisim site = _contactRepository.Get();

            site.Adres = GenelFonksiyonlar.BRDonusturEnter(site.Adres);

            return PartialView("Iletisim", site);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [ValidateInput(false)]   
        public PartialViewResult SiteIletisimKaydet(SiteIletisim iletisim)
        {
            try
            {
              _contactRepository.Update(iletisim);
              ViewData["mesaj"] = "Kayıt Başarı ile Güncellendi.";

            }
            catch (Exception ex)
            {
                ViewData["mesaj"] = ex.ToString();
                return PartialView("Error");
            }

            return PartialView("Successful");    
        }

        public PartialViewResult MailSMTPClint()
        {
            return PartialView(_mailInfoRepository.Get());
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public PartialViewResult MailSMTPClintKaydet(MailBilgi mailBilgi)
        {
            try
            {
             _mailInfoRepository.Update(mailBilgi);
             ViewData["mesaj"] = "Kayıt Başarı ile Güncellendi.";
            }
            catch (Exception ex)
            {
                ViewData["mesaj"] = ex.ToString();
                return PartialView("Error");
            }

            return PartialView("Successful");
        }
    }
}
