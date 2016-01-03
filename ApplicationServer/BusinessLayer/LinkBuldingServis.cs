using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BusinessLayer
{
    public class LinkBuldingServis
    {
        public static string Content(string baslik, string link, string dil, int id)
        {
            if (link == null)
            {
                return string.Format("~/{0}/{1}/{2}", dil, UrlTRKarekter.Replace(baslik), id);
            }
            else
            {
                return string.Format("~/{0}/{1}", dil, link);
            }
        }

        public static string UrunDetay(string urunAdi, string dil, int id)
        {
            return string.Format("~/{0}/UrunDetay/{1}/{2}", dil, UrlTRKarekter.Replace(urunAdi), id);
        }

        public static string Duyrular(string action, string controller, string dil, int id)
        {
            return string.Format("~/{0}/{1}/{2}/duyuruID={3}/", dil, controller, action, id.ToString());

        }
    }
}
