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
    public class SiteDilController : BaseAdminController
    {
        private ILanguageRepository _languageRepository;

        public SiteDilController(ILanguageRepository languageRepository)
        {
            this._languageRepository = languageRepository;
        }


        public ActionResult Index()
        {
            return View(_languageRepository.FindAll());
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(SiteDil siteDil, HttpPostedFileBase Icon)
        {
            try
            {
                if (Path.GetExtension(Icon.FileName) == ".png")
                {
                    string fileName = siteDil.Kodu + ".png";
                    Icon.SaveAs(Server.MapPath("~/Content/Products/Sayfa/" + fileName));

                    siteDil.Icon = fileName;
                    _languageRepository.Insert(siteDil);

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", " Icon uzantısı png olmalıdır.");
                }
            }
            catch(Exception ex)
            {
                Error(this, ex.ToString());
            }

            return View(siteDil);  
        }

        public ActionResult Delete(int id, string icon)
        {
            try
            {
                FileInfo fi = new FileInfo(Server.MapPath("~/Content/Products/Sayfa/" + icon));
                if (fi.Exists)
                    fi.Delete();

                _languageRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Durum(int id, Boolean durum)
        {
            try
            {
                _languageRepository.State(id, durum);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
