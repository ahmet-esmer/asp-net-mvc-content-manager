using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MicroOptik.WebUI.Models;


namespace MicroOptik.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {

        public static MvcHtmlString Sayfalama(this AjaxHelper helper, int SayfaNo, int ToplamKayit,
            string ActionName,int SayfaGosterim = 3, string HedefDiv = "icerik" )
        {
            if (ToplamKayit >= SayfaGosterim)
            {
                AjaxOptions ao = new AjaxOptions();
                ao.UpdateTargetId = HedefDiv;
                ao.LoadingElementId = "progress";

                StringBuilder sb = new StringBuilder();
                int ToplamSayfaSayisi = 0;
                object ilkYaz = "";
                object geriYaz = "";
                object ileriYaz = "";
                object sonYaz = "";

                if (ToplamKayit % SayfaGosterim == 0)
                    ToplamSayfaSayisi = ToplamKayit / SayfaGosterim;
                else
                    ToplamSayfaSayisi = ToplamKayit / SayfaGosterim + 1;


                #region Sayfa 10 Adet Gösterme
                int ilkGosterim = SayfaNo;
                int sonGosterim = SayfaNo;

                if (ToplamSayfaSayisi - 1 == SayfaNo)
                    ilkGosterim = ilkGosterim - 9;

                else if (ToplamSayfaSayisi - 2 == SayfaNo)
                    ilkGosterim = ilkGosterim - 8;

                else if (ToplamSayfaSayisi - 3 == SayfaNo)
                    ilkGosterim = ilkGosterim - 7;

                else if (ToplamSayfaSayisi - 4 == SayfaNo)
                    ilkGosterim = ilkGosterim - 6;

                else
                    ilkGosterim = ilkGosterim - 5;


                switch (sonGosterim)
                {
                    case 0: sonGosterim = 10; break;
                    case 1: sonGosterim = 10; break;
                    case 2: sonGosterim = 10; break;
                    case 3: sonGosterim = 10; break;
                    case 4: sonGosterim = 10; break;
                    default: sonGosterim = sonGosterim + 5; break;
                }

                #endregion

                #region İlk Sayfa ve En son Sayfa İşlemi

                if (!(ToplamSayfaSayisi <= 10))
                {
                    if (SayfaNo == ToplamSayfaSayisi - 1)
                    {
                        sonYaz = "<span class='Last Page' > Son Sayfa </span>\n";
                    }
                    else
                    {
                        sonYaz = AjaxExtensions.ActionLink(helper, "Son Sayfa", ActionName, new { Sayfa = ToplamSayfaSayisi - 1 }, ao, new { @class = "Last Page" });
                    }


                    if (SayfaNo == 0)
                    {
                        ilkYaz = "<span class='First Page' > İlk Sayfa </span>\n";
                    }
                    else
                    {
                        ilkYaz = AjaxExtensions.ActionLink(helper, "İlk Sayfa", ActionName, new { Sayfa = 0 }, ao, new { @class = "First Page" });
                    }
                }
                #endregion


                for (int i = 0; i < ToplamSayfaSayisi; i++)
                {
                    if (i >= ilkGosterim && i < sonGosterim)
                    {
                        if (i == SayfaNo)
                        {
                            sb.Append("<a class='current' >" + (i + 1) + "</a>\n");
                        }
                        else
                        {
                            sb.Append(AjaxExtensions.ActionLink(helper, Convert.ToString((i + 1)), ActionName, new { Sayfa = (i) }, ao, new { @class = "number" }));
                        }
                    }
                }

                #region Sayfa İleri Geri İşlemi
                SayfaNo = SayfaNo + 1;
                int geri = SayfaNo - 2;

                if (geri < 0)
                {
                    geriYaz = "<span class='Previous Page' > « Geri </span>\n";
                }
                else
                {
                    geriYaz = AjaxExtensions.ActionLink(helper, "« Geri", ActionName, new { Sayfa = geri }, ao, new { @class = "Previous Page" });
                }

                if (SayfaNo >= ToplamSayfaSayisi)
                {
                    ileriYaz = "<span class='Next Page' > İleri » </span>\n";
                }
                else
                {
                    ileriYaz = AjaxExtensions.ActionLink(helper, "İleri »", ActionName, new { Sayfa = SayfaNo }, ao, new { @class = "Next Page" });
                }

                #endregion

                string toplamMetin = "<div class='pageTotal' > Toplam: " + ToplamKayit.ToString() + "</div>";

                return MvcHtmlString.Create(ilkYaz.ToString() + geriYaz.ToString() + sb.ToString() + ileriYaz.ToString() + sonYaz.ToString() + toplamMetin);
            }
            else
            {
                return MvcHtmlString.Create("");
            }
        } 
    }
}