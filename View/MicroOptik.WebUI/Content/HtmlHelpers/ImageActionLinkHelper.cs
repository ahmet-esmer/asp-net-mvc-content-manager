using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Ajax;
using System.Web.Mvc;
using System.Text;

namespace MicroOptik.WebUI.Content.HtmlHelpers
{
    public static class ImageActionLinkHelper
    {
        public static MvcHtmlString ActionImageLink(this AjaxHelper helper, string imageUrl, string text,
            string actionName, string controller, object routeValues, AjaxOptions ajaxOptions)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<span>");
            sb.Append("<img ");
            sb.Append("alt='"+ text+"'");
            sb.Append("src='"+ imageUrl +"' />");
            sb.Append("<br />");
            sb.Append(text);
            sb.Append("</span>");


            var link = helper.ActionLink("[replaceme]", actionName, controller, routeValues, ajaxOptions, new { Class = "shortcut-button" });
            return new MvcHtmlString(link.ToHtmlString().Replace("[replaceme]", sb.ToString()));
        }

    }
}