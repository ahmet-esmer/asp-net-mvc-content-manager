using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelLayer;
using MicroOptik.WebUI.Infrastructure.BasePages;

namespace MicroOptik.WebUI.Controllers
{
    public class IncludeController : BaseSiteController
    {
    
        private readonly IContentTitleRepository _contentTitleRepostory;
        private readonly IContentRepository _contentRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IAnnouncementRepository _announcementRepository;


        public IncludeController(IContentRepository contentRepository, 
            IContentTitleRepository contentTitleRepository,
            IImageRepository imageRepository,
            ILanguageRepository languageRepository,
            IContentTitleRepository icerikBaslikRepostory,
            IAnnouncementRepository announcementRepository
            )
        {
            _contentRepository = contentRepository;
            _imageRepository = imageRepository;
            _languageRepository = languageRepository;
            _contentTitleRepostory = icerikBaslikRepostory;
            _announcementRepository = announcementRepository;
        }



        [ChildActionOnly]
        public ActionResult TopMenuLinks(string culture)
        {
            return PartialView(_contentTitleRepostory.PageLink(culture, "Ana Menu"));
        }

        [ChildActionOnly]
        public ActionResult Banner(string culture)
        {
            return PartialView(_imageRepository.FindBanner("Banner", culture));
        }
   
        [ChildActionOnly]
        public ActionResult LanguageLinks()
        {
            return PartialView(_languageRepository.FindAll());
        }

        [ChildActionOnly]
        public ActionResult Announcement(string culture)
        {
            return PartialView(_announcementRepository.PanelList(culture));
        }
    }
}
