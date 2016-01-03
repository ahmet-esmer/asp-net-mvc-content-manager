using System;
using System.Text;
using System.Web.Mvc;
using MailLibrary;
using MicroOptik.WebUI.Infrastructure.BasePages;
using MicroOptik.WebUI.Models;
using ModelLayer;
using RepositoryLayer;
using System.Web;

namespace MicroOptik.WebUI.Controllers
{
    public class ContentController : BaseSiteController
    {
        private Icerik icerik;
        private readonly IContentTitleRepository _contentTitleRepostory;
        private readonly IContentRepository _contentRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IAnnouncementRepository _announcementRepository;
        private  IContactRepository _contactRepository;

        public ContentController(IContentTitleRepository contentTitleRepository,
            IContentRepository contentRepository,
            IImageRepository imageRepository,
            ILanguageRepository languageRepository,
            IAnnouncementRepository announcementRepository,
            IContactRepository contactRepository)
        {
            _contentTitleRepostory = contentTitleRepository;
            _contentRepository = contentRepository;
            _imageRepository = imageRepository;
            _languageRepository = languageRepository;
            _announcementRepository = announcementRepository;
            _contactRepository = contactRepository;
        }


        public ActionResult PageContent(int icBaslikId)
        {
            IcerikGetById(icBaslikId);
            return View(icerik);
        }

        public ActionResult Announcement(string culture)
        {
            return View(_announcementRepository.FindByLang(culture));
        }

        public ActionResult Contact(string culture)
        {
            IcerikGetAction("Iletisim",culture);
            ViewBag.Iletisim = _contactRepository.Get();
            return View();
        }

        public ActionResult Brand(string culture)
        {
            IcerikGetAction("Markalar", culture);
            return View(_imageRepository.FindBanner("Marka", "tr"));
        }

        [HttpPost]
        public ActionResult Contact(IletisimFormu sendForm)
        {
            string captcha = Session["captchaStr"] as string;

            if (ModelState.IsValid)
            {
                if (captcha == sendForm.Captcha)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<b>Gönderen:</b>" + sendForm.AdSoyad + "  <br>");
                    sb.Append("<b>E-Posta:</b>" + sendForm.Eposta + " <br>");
                    sb.Append("<b>İrtibat Telefonu: </b>" + sendForm.Telefon + "<br>");
                    sb.Append("<b>Firma Adı: </b>" + sendForm.FiramaAdi + "<br>");
                    sb.Append("<b>Mesaj: </b>" + sendForm.Mesaj + "<br>");

                    MailManager.Admin.Send("mikrooptik@superonline.com",
                        "Mikro Optik Web Sitesi İletişim Formu", sb.ToString());

                    Successful(this, Resources.ContactForm.MesajOk);
                    return RedirectToAction("Contact");
                }
                else
                {
                    ModelState.AddModelError("", Resources.ContactForm.RegCaptchaGec);
                    ModelState.AddModelError("Captcha", Resources.ContactForm.RegCaptchaGec);  
                }
            }

            return View(sendForm);
        }

        private void IcerikGetById(int icBaslikId)
        {
            icerik = _contentRepository.FindByIcerikId(icBaslikId);

            if (icerik == null)
            {
                throw new HttpException(404, "İstenilen Sayfa Bulunamadı.");
            }
            else
            {
                ViewBag.Title = icerik.Title;
                ViewBag.Description = icerik.Description;
                ViewBag.Keywords = icerik.Keywords;
            }
        }

        private void IcerikGetAction(string actionName, string culture)
        {
            icerik = _contentRepository.FindByActionName(culture, actionName);

            if (icerik == null)
                throw new HttpException(404, "İstenilen Sayfa Bulunamadı.");
            else
            {
                ViewBag.Title = icerik.Title;
                ViewBag.Description = icerik.Description;
                ViewBag.Keywords = icerik.Keywords;
            }
        }
    }
}
