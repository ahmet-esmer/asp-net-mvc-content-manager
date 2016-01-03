using System.ComponentModel;
using System.Web;
using System.Web.Mvc;
using MicroOptik.WebUI.Infrastructure;
using MicroOptik.WebUI.Infrastructure.BasePages;
using ModelLayer;
using ModelLayer.ModelView;
using RepositoryLayer;
using Resources;

namespace MicroOptik.WebUI.Controllers
{
    public class ProductController : BaseSiteController
    {
        private Icerik icerik;
        private IContentTitleRepository _contentTitleRepostory;
        private IContentRepository  _contentRepository;
        private IImageRepository _imageRepository;
        private ILanguageRepository _languageRepository;


        public ProductController(IContentTitleRepository contentTitleRepository,
            IContentRepository contentRepository,
            IImageRepository imageRepository,
            ILanguageRepository languageRepository)
        {
            _contentTitleRepostory = contentTitleRepository;
            _contentRepository = contentRepository;
            _imageRepository = imageRepository;
            _languageRepository = languageRepository;
        }


        public ActionResult Products(string culture)
        {
            IcerikGetAction("Urunler", culture);
            ViewBag.Icerik = icerik.SayfaIcerik;

            return View(_contentTitleRepostory.UrunLink(culture).KategoriSirala());
        }

        public ActionResult ProductSearch([DefaultValue(0)] int Sayfa, string culture, string searchKey)
        {
            ViewBag.KategoriLink = _contentTitleRepostory.UrunLink(culture).KategoriSirala();
          
            PagingModel page = new PagingModel
            {
                ViewItems = 2,
                Culture = culture,
                CurentPage = Sayfa,
                SearchKey = searchKey
            };

            page.TotolItem = _contentRepository.ProductSearchCount(page);

            if (page.TotolItem == 0)
            {
                ViewBag.Mesaj = Strings.SearchMesaj3;
            }
            else
            {
                ViewBag.Mesaj = string.Format("{0} <b>{1}</b> {2}", Strings.SearchMesaj1, page.TotolItem, Strings.SearchMesaj2);
            }

            ViewBag.Paging = Paging.Number(page);

            return View(_contentRepository.ProductSearchList(page));
        }

        public ActionResult ProductList([DefaultValue(0)] int Sayfa, string culture, int icBaslikId)
        {
            IcerikGetById(icBaslikId);
            UrunKategori();

            PagingModel page = new PagingModel
            {
                ViewItems = 9,
                Culture = culture,
                CurentPage = Sayfa,
                IcBaslikId = icerik.BaslikId,
            };

            page.TotolItem = _contentRepository.ProductListCount(page);
            ViewBag.Paging = Paging.Number(page);

            return View(_contentRepository.ProductList(page));
        }

        public ActionResult ProductMainPage(string culture, int icBaslikId)
        {
            PagingModel page = new PagingModel
            {
                ViewItems = 3,
                Culture = culture,
                CurentPage = 0,
                IcBaslikId = icBaslikId,
            };

            return PartialView(_contentRepository.ProductList(page));
        }

        public ActionResult ProductDetail(string culture, int icBaslikId)
        {
            IcerikGetById(icBaslikId);
            UrunKategori();

            ViewBag.ProductImages = _imageRepository.FindAll(icerik.BaslikId, "galeri");
           
            return View();
        }

        private void UrunKategori()
        {
           ViewBag.KategoriLink = _contentTitleRepostory.UrunLink(icerik.Dil, icerik.BaslikId).KategoriSirala();
        }

        private void IcerikGetById(int icBaslikId)
        {
            icerik = _contentRepository.FindByIcerikId(icBaslikId);

            if (icerik == null)
                throw new HttpException(404, "İstenilen Sayfa Bulunamadı");
            else
            {
                ViewBag.Title = icerik.Title;
                ViewBag.Description = icerik.Description;
                ViewBag.Keywords = icerik.Keywords;
                ViewBag.Icerik = icerik.SayfaIcerik;
                ViewBag.Brosur = icerik.Brosur;
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
