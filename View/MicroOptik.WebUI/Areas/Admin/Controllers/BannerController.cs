using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using MicroOptik.WebUI.Infrastructure.Authorization;
using MicroOptik.WebUI.Infrastructure.BasePages;
using ModelLayer;

namespace MicroOptik.WebUI.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class BannerController : BaseAdminController
    {

        private IImageRepository _imageRepository;
        private ILanguageRepository _languageRepository;

        public BannerController(IImageRepository imageRepository, ILanguageRepository languageRepository)
        {
            this._imageRepository = imageRepository;
            this._languageRepository = languageRepository;
        }

        public ActionResult Index()
        {
            return View(_imageRepository.FindAll("Banner","Marka"));
        }

        public ActionResult Create()
        {
            SiteDileri();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Resim resim, HttpPostedFileBase Adi )
        {
            try
            {
                    string resimAdi = ImageLibrary.Images.GetImageName(Path.GetExtension(Adi.FileName));
                    Adi.SaveAs(Server.MapPath("~/Content/Products/Sayfa/" + resimAdi));

                    resim.Adi = resimAdi;
                  
                    _imageRepository.Insert(resim);
                    Successful(this, "Banner kaydı başarı ile oluştulurdu.");

                    return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Error(this, ex.ToString());
            }

            SiteDileri();
            return View();
        }


        public ActionResult Delete(int id, string resim)
        {
            try
            {
                ResimSil(resim);
                _imageRepository.Delete(id);
            }
            catch(Exception ex)
            {
                Error(this, ex.ToString());
            }

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            SiteDileri();

            return View(_imageRepository.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection, Resim resim, HttpPostedFileBase Adi)
        {
            try
            {
                resim.Adi = collection["resimAdi"];

                if (Adi != null)
                {
                    ResimSil(resim.Adi);

                    string resimAdi = ImageLibrary.Images.GetImageName(Path.GetExtension(Adi.FileName));
                    Adi.SaveAs(Server.MapPath("~/Content/Products/Sayfa/" + resimAdi));
                    resim.Adi = resimAdi;
                }
               
                _imageRepository.Update(resim);
                Successful(this, "Banner kaydı başarı ile güncellendi.");

                return RedirectToAction("Index");  
            }
            catch (Exception ex)
            {
                Error(this, ex.ToString());
                SiteDileri();
                return View(resim);
            }
        }

        private void SiteDileri()
        {
            ViewData["SiteDil"] = _languageRepository.FindAll();
        }


        private void ResimSil(string resimAdi)
        {
            FileInfo fi = new FileInfo(Server.MapPath("~/Content/Products/Sayfa/" + resimAdi));
            if (fi.Exists)
                fi.Delete();
        }
    }
}
