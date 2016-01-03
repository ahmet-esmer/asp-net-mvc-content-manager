using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using MicroOptik.WebUI.Infrastructure.BasePages;
using System.Text;
using Resources;

namespace MicroOptik.WebUI.Controllers
{
    public class ErrorController : BaseSiteController
    {

        public ActionResult Page(string culture)
        {
          
            StringBuilder sb = new StringBuilder();
            sb.Append("<span class='title'>");
            sb.Append(Strings.UygTitle);
            sb.Append("</span>");
            sb.Append("<a href='");
            sb.Append(Url.Content("~/"+culture +"/Iletisim"));
            sb.Append("' class='link'>");
            sb.Append(Strings.UygMesaj);
            sb.Append("</a>");
            sb.Append("<a class='link pading' href='"+ VirtualPathUtility.ToAbsolute("~/")+ culture +"/index' >" + Strings.UygLink + "</a>");

             
            Error(this, sb.ToString());
            
            return View();
        }


        public ActionResult Http404(string culture)
        {

            Alert(this, "<span class='title' >HTTP 404 </span> <span class='appText pading '>" + 
                Strings.Title404 + " </span>");

            return View();
        }


        public ActionResult ApplicationError(string culture)
        {
            return View();
        }

        //private void ErrorPage()
        //{
        //     UrlEncoder urlEncoder = new UrlEncoder();
        //     string errorurl;
        //    if (RouteData.Values["errorurl"] != null)
        //    {
        //        errorurl = urlEncoder.URLDecode(RouteData.Values["errorurl"].ToString());
        //    }
        
        //}
    }
}
