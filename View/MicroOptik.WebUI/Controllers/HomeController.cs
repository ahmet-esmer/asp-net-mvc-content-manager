using System.Web.Mvc;
using MicroOptik.WebUI.Infrastructure.BasePages;
using ModelLayer;
using RepositoryLayer;

namespace MicroOptik.WebUI.Controllers
{
    public class HomeController : BaseSiteController
    {
        private readonly IContentRepository _contentRepository;
        private readonly IContentTitleRepository _contentTitleRepostory;

        public HomeController(IContentRepository contentRepository,
            IContentTitleRepository contentTitleRepository)
        {
            _contentRepository = contentRepository;
            _contentTitleRepostory = contentTitleRepository;
        }

        //[AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index(string culture)
        {
            ViewBag.UrunLink = _contentTitleRepostory.UrunLink(culture).KategoriSirala();
            return View(_contentRepository.FindByActionName(culture, "index"));
        }


    }
}
