using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace MicroOptik.WebUI.Content.HtmlHelpers
{
    public static class UpdateLinkExtension
    {

        public static HtmlString UpdateLink(this HtmlHelper html,  
                                       string controller, string action, int id )
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var url = urlHelper.Action(action, controller, new { id=id });

            string adres = urlHelper.Content("~/Areas/Admin/Content/images/");

            StringBuilder sb = new StringBuilder();
            sb.Append("<a ");
            sb.Append("href='" + url + "' >");

            sb.Append("<img src='" + adres + "pencil.png' border='0' />");
           
            sb.Append("</ a>");

            return new HtmlString(sb.ToString());
        }

        public static HtmlString UpdateLink(this HtmlHelper html,
                                      string controller, string action, object queryPrm )
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var url = urlHelper.Action(action, controller, queryPrm);

            string adres = urlHelper.Content("~/Areas/Admin/Content/images/");

            StringBuilder sb = new StringBuilder();
            sb.Append("<a ");
            sb.Append("href='" + url + "' >");

            sb.Append("<img src='" + adres + "pencil.png' border='0' />");

            sb.Append("</ a>");

            return new HtmlString(sb.ToString());
        }


    }
}