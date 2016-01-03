using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace MicroOptik.WebUI.Content.HtmlHelpers
{
    public static class DurumExtension
    {

        public static HtmlString DurumLink(this HtmlHelper html,  
                                       string controller, string action, Boolean durum, int id )
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var url = urlHelper.Action(action, controller, new { durum= durum, id=id });

            string adres = urlHelper.Content("~/Areas/Admin/Content/images/");

            StringBuilder sb = new StringBuilder();
            sb.Append("<a ");
            sb.Append("href='" + url + "' >");

            if (durum == true)
                sb.Append("<img src='" + adres + "aktiv.gif' border='0' />");  
            else
                sb.Append("<img src='" + adres + "pasif.gif' border='0' />");
           
            sb.Append("</ a>");

            return new HtmlString(sb.ToString());
        }

        public static HtmlString DurumLink(this HtmlHelper html,
                                      string controller, string action, object queryParm, Boolean durum)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var url = urlHelper.Action(action, controller, queryParm);

            string adres = urlHelper.Content("~/Areas/Admin/Content/images/");

            StringBuilder sb = new StringBuilder();
            sb.Append("<a ");
            sb.Append("href='" + url + "' >");

            if (durum == true)
                sb.Append("<img src='" + adres + "aktiv.gif' border='0' />");
            else
                sb.Append("<img src='" + adres + "pasif.gif' border='0' />");

            sb.Append("</ a>");

            return new HtmlString(sb.ToString());
        }


        public static HtmlString DurumIcon(this HtmlHelper html, Boolean durum )
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            string adres = urlHelper.Content("~/Areas/Admin/Content/images/");
            StringBuilder sb = new StringBuilder();

            if (durum == true)
                sb.Append("<img src='" + adres + "aktiv.gif' border='0' />");
            else
                sb.Append("<img src='" + adres + "pasif.gif' border='0' />");


            return new HtmlString(sb.ToString());
        }

    }
}