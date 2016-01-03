using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MicroOptik.WebUI.Content.HtmlHelpers
{
    public static class ImageHelper
    {


        public static HtmlString Image(this HtmlHelper helper, string src, string alt)
        {
            UrlHelper urlHelper = ((Controller)helper.ViewContext.Controller).Url;
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", urlHelper.Content("~/" + src));
            tb.Attributes.Add("alt", helper.Encode(alt));
            return new HtmlString( tb.ToString(TagRenderMode.SelfClosing));
        }



        private static string Image(string imgSrc, string alt, object imgHtmlAttributes)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", imgSrc);
            tb.Attributes.Add("alt", alt);

            return tb.ToString(TagRenderMode.SelfClosing);
        }


        public static HtmlString ImageLink(this HtmlHelper htmlHelper, string imgSrc, string alt,
            string actionName, string controllerName, object routeValues, object htmlAttributes, 
            object imgHtmlAttributes)
        {
            UrlHelper urlHelper = ((Controller)htmlHelper.ViewContext.Controller).Url;

            string imgtag = Image(imgSrc, alt, imgHtmlAttributes);
            string url = urlHelper.Action(actionName, controllerName, routeValues);


            TagBuilder imglink = new TagBuilder("a");
            imglink.MergeAttribute("href", url);
            imglink.InnerHtml = imgtag;
            imglink.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);

            return new HtmlString(imglink.ToString());

        }

       

        

    }
}