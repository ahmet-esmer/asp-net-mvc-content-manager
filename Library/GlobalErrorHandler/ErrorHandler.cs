using System;
using System.IO;
using System.Text;
using System.Web;
using ConfigLibrary;
using LoggerLibrary;

namespace GlobalErrorHandler
{
    public class ErrorHandler : IHttpModule
    {

        public void Dispose()
        {

        }

        public void Init(HttpApplication app)
        {
            app.Error += new EventHandler(app_Error);
        }

        void app_Error(object sender, EventArgs e)
        {
            try
            {
                HttpContext context = HttpContext.Current;
                HttpRequest request = context.Request;
                HttpResponse response = context.Response;
                Exception exception = context.Server.GetLastError();
                HttpException httpException = exception as HttpException;
                Exception exceptionBase = exception.GetBaseException();
                HttpBrowserCapabilities browser = request.Browser;

                string controller = "Error";
                string action = "Page";
                string culture = context.Request.RequestContext.RouteData.Values["culture"] as string;

                if (culture == null)
                {
                    culture = "tr";
                }

                StringBuilder sp = new StringBuilder();
                sp.Append("<h6>Gelen URL</h6>" + request.ServerVariables["HTTP_REFERER"]);
                sp.Append("<h6>URL</h6>" + context.Server.HtmlEncode(context.Request.Url.ToString()));
                sp.Append("<h6>Clint Info</h6>");
                sp.Append(" BrowserTuru: " + browser.Browser + "<br/>");
                sp.Append(" BrowserAdi: " + browser.Type + "<br/>");
                sp.Append(" BrowserVersiyonu: " + browser.Version + "<br/>");
                sp.Append("<h6>Exception</h6> " + context.Server.HtmlEncode(exceptionBase.ToString()));
                sp.Append("<h6>Exception Source </h6> " + exceptionBase.Source);
                sp.Append("<h6>Stack Trace </h6> " + exceptionBase.StackTrace);
                sp.Append("<h6>TargetSite </h6> " + exceptionBase.TargetSite);
                sp.Append("<h6>--- Form Parametre ---</h6>");

                for (int i = 0; i < request.Form.Count; i++)
                {
                    if (i > 6)
                    {
                        sp.Append(request.Form.Keys[i].ToString() + ": " + request.Form[i].ToString() + "<br/>");
                    }
                }

                if (httpException != null)
                {
                    switch (httpException.GetHttpCode())
                    {
                        case 404:
                            action = "Http404";
                            break;
                    }
                }

                //LogManager.SqlDB.Write(exception.Message, sp.ToString());

                if (action != "Http404")
                {
                    LogManager.SqlDB.Write(exception.Message, sp.ToString());
                }


                context.Server.ClearError();
                response.Redirect(string.Format("~/{0}/{1}/{2}", culture, controller, action));
               
            }
            catch (Exception ex)
            {
                ApplicationErrorWrite(ex);
            }
        }

        private void ApplicationErrorWrite(Exception exception)
        {

            FileStream fs = new FileStream(ConfigHelper.GetPhysicalPath(@"Logs\Application.txt"),
                FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fs);
            streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            streamWriter.WriteLine(" ");
            streamWriter.WriteLine(exception.Message);
            streamWriter.WriteLine("İşlem Tarihi: " + DateTime.Now.ToString("dd MMMM yyyy dddd HH:mm"));
            streamWriter.WriteLine("Hata Mesaj  : " + exception.ToString());
            streamWriter.WriteLine("-------------------------------------------------------------------------");
            streamWriter.Flush();
            streamWriter.Close();

            HttpContext.Current.Response.Redirect("~/tr/Error/ApplicationError");
        }

    }
}
