using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace MicroOptik.WebUI.Content.HtmlHelpers
{
    public class AjaxMesaj
    {
        public static string Successful(string mesaj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language='javascript'>");
            sb.Append("$('#mesajlar').html(\"");
            sb.Append("<div class='mesaj success' >");
            sb.Append("<div class='close' > &nbsp; </div>");
            sb.Append("<span>" + mesaj + "</span>");
            sb.Append("\").slideDown(400);");
            sb.Append("setTimeout(\"");
            sb.Append("$('.close').parent().fadeTo(400, 0, function () { ");
            sb.Append("$('#mesajlar').slideUp(400);");
            sb.Append("});");
            sb.Append("\", 4500);");
            sb.Append("</script>");
            return sb.ToString();
        }

        public static string Info(string mesaj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language='javascript'>");
            sb.Append("$('#mesajlar').html(\"");
            sb.Append("<div class='mesaj info' >");
            sb.Append("<div class='close' > &nbsp; </div>");
            sb.Append("<span>" + mesaj + "</span>");
            sb.Append("\").slideDown(400);");
            sb.Append("setTimeout(\"");
            sb.Append("$('.close').parent().fadeTo(400, 0, function () { ");
            sb.Append("$('#mesajlar').slideUp(400);");
            sb.Append("});");
            sb.Append("\", 4500);");
            sb.Append("</script>");
            return sb.ToString();
        }

        public static string Alert(string mesaj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language='javascript'>");
            sb.Append("$('#mesajlar').html(\"");
            sb.Append("<div class='mesaj alert' >");
            sb.Append("<div class='close' > &nbsp; </div>");
            sb.Append("<span>" + mesaj + "</span>");
            sb.Append("\").slideDown(400);");
            sb.Append("setTimeout(\"");
            sb.Append("$('.close').parent().fadeTo(400, 0, function () { ");
            sb.Append("$('#mesajlar').slideUp(400);");
            sb.Append("});");
            sb.Append("\", 4500);");
            sb.Append("</script>");
            return sb.ToString();
        }

        public static string Error(string mesaj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language='javascript'>");
            sb.Append("$('#mesajlar').html(\"");
            sb.Append("<div class='mesaj error' >");
            sb.Append("<div class='close' > &nbsp; </div>");
            sb.Append("<span>" + mesaj + "</span>");
            sb.Append("\").slideDown(400);");
            sb.Append("setTimeout(\"");
            sb.Append("$('.close').parent().fadeTo(400, 0, function () { ");
            sb.Append("$('#mesajlar').slideUp(400);");
            sb.Append("});");
            sb.Append("\", 4500);");
            sb.Append("</script>");
            return sb.ToString();
        }
    }
}