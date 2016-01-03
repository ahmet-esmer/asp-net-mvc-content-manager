using System;
using System.ComponentModel;
using System.IO;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using ImageLibrary;
using MicroOptik.WebUI.Content.HtmlHelpers;
using MicroOptik.WebUI.Infrastructure.Authorization;
using MicroOptik.WebUI.Infrastructure.BasePages;
using ModelLayer;

namespace MicroOptik.WebUI.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class IcerikController : BaseAdminController
    {
        private IContentRepository  _contentRepository;
        private IContentTitleRepository _contentTitleRepository;
        private IImageRepository _imageRepository;
        private ILanguageRepository _languageRepository;

        public IcerikController(IContentRepository contentRepository,
            IContentTitleRepository contentTitleRepository,
            IImageRepository imageRepository,
            ILanguageRepository languageRepository
            )
        {
            this._contentRepository = contentRepository;
            this._contentTitleRepository = contentTitleRepository;
            this._imageRepository = imageRepository;
            this._languageRepository = languageRepository;
        }


        public ActionResult Edit([DefaultValue(false)]Boolean resim, int BaslikId, string dil)
        {
            IcerikBaslikBilgi(BaslikId);
            SiteDileri();
            ViewBag.resimler = _imageRepository.FindAll(BaslikId, "galeri");

           return View(_contentRepository.FindById(BaslikId, dil));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Icerik icerik, HttpPostedFileBase brosurFile)
        {
            try
            {
                if (brosurFile != null)
                {
                    string extension = Path.GetExtension(brosurFile.FileName);
                    string brosur =
                        UrlTRKarekter.Replace(Path.GetFileNameWithoutExtension(brosurFile.FileName)) + extension;

                    brosurFile.SaveAs(Server.MapPath("~/Content/Products/Brosur/" + brosur));
                    icerik.Brosur = brosur;
                }

                SiteDileri();
                _contentRepository.Update(icerik);
                Successful(this, "Kayıt başarı ile güncellendi.");
            }
            catch (Exception ex)
            {
                Error(this, ex.ToString());
            }

            return RedirectToAction("Index", "IcerikBaslik", new { dil = icerik.Dil });
        }


        public ActionResult Create(int BaslikId)
        {
            SiteDileri();
            ViewBag.resimler = _imageRepository.FindAll(BaslikId, "galeri");
            IcerikBaslikBilgi(BaslikId);
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(Icerik icerik, HttpPostedFileBase brosurFile)
        {
            try
            {
                if (brosurFile != null)
                {
                    string extension = Path.GetExtension(brosurFile.FileName);
                    string brosur =
                        UrlTRKarekter.Replace(Path.GetFileNameWithoutExtension(brosurFile.FileName)) + extension;

                    brosurFile.SaveAs(Server.MapPath("~/Content/Products/Brosur/" + brosur));
                    icerik.Brosur = brosur;
                }

                _contentRepository.Insert(icerik);
                Successful(this, "Sayfa içerigi başarı ile oluşturuldu.");     
            }
            catch (Exception ex)
            {
                Error(this, ex.ToString());
            }

            return RedirectToAction("Index", "IcerikBaslik", new { dil = icerik.Dil});
        }


        // Resim işlemleri 
        public ActionResult ResimUpload(FormCollection collection, HttpPostedFileBase resim)
        {
            try
            {
                string resimAdi = ImageLibrary.Images.GetImageName(Path.GetExtension(resim.FileName));
                resim.SaveAs(Server.MapPath("~/Content/Products/Big/" + resimAdi));
                Images.SmallImage.Save(resimAdi, 250);
                Images.LittleImage.Save(resimAdi, 100);

                int BaslikId = Convert.ToInt32(collection["BaslikId"]);
                Resim _resim = new Resim
                {
                    Adi = resimAdi,
                    Baslik = collection["resimBaslik"],
                    GenelId = BaslikId,
                    Parametre = "galeri",
                    Sira = 1
                };

                _imageRepository.Insert(_resim);

            }
            catch (Exception ex)
            {
                Error(this, ex.ToString());
            }
           
            return Redirect(collection["hdfRetUrl"] + "&resim=true");
        }

        public JsonResult ResimSiralama(int id, int sira)
        {
            try
            {
                Resim _resim = _imageRepository.FindById(id);
                _resim.Sira = sira;
                _imageRepository.Update(_resim);
            }
            catch (Exception ex)
            {
                return Json(new {message = AjaxMesaj.Successful(ex.ToString())});
            }

            return Json(new {message = AjaxMesaj.Successful("Siralama işlemi başarı ile yapıldı.") });
        }

        public JsonResult ResimBaslik(int id, string baslik)
        {
            try
            {
                Resim _resim = _imageRepository.FindById(id);
                _resim.Baslik = baslik;
                _imageRepository.Update(_resim);
            }
            catch (Exception ex)
            {
                return Json(new { message = AjaxMesaj.Successful(ex.ToString())});
            }
            return Json(new { message = AjaxMesaj.Successful("Güncelleme işlemi başarı ile yapıldı.")});
        }

        public JsonResult ResimSil(int id, string resimAdi)
        {
            try
            {
                Images.BigImage.Delete(resimAdi);
                Images.LittleImage.Delete(resimAdi);
                Images.SmallImage.Delete(resimAdi);

                _imageRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return Json(new { message = AjaxMesaj.Successful(ex.ToString()) });
            }
            return Json(new { message = AjaxMesaj.Successful("Güncelleme işlemi başarı ile yapıldı.") });
        }

        private void IcerikBaslikBilgi(int BaslikId)
        {
            IcerikBaslik baslik = _contentTitleRepository.FindById(BaslikId);
            ViewData["baslik"] = baslik.KategoriAdi;
            ViewData["BaslikId"] = BaslikId;
        }

        private void SiteDileri()
        {
            ViewData["SiteDil"] = _languageRepository.FindDropDownList();
        }

    }
}
