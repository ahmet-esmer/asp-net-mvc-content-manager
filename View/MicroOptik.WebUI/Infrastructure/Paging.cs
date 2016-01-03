using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Text;
using ModelLayer.ModelView;
using Resources;

namespace MicroOptik.WebUI.Infrastructure
{
    public class Paging
    {
        private static int ToplamKayit;



        public static string Number(PagingModel page)
        {
            //Demo
            NameValueCollection queryString = new NameValueCollection();
            queryString.Add("Sayfa", page.CurentPage.ToString());

            ToplamKayit = page.TotolItem;
            return sayfaNoOlustur(queryString, page.ViewItems);
        }

        public static string Number(int sayfa, int sayfaGosterim, int toplamKayit)
        {
            //Demo
            NameValueCollection queryString = new NameValueCollection();
            queryString.Add("Sayfa", sayfa.ToString());

            ToplamKayit = toplamKayit;
            return sayfaNoOlustur(queryString, sayfaGosterim);
        }

        public static string Number(NameValueCollection queryString, int sayfaGosterim, int toplamKayit)
        {
            ToplamKayit = toplamKayit;
            return sayfaNoOlustur(queryString, sayfaGosterim);
        }


        #region Sayfa Listeleme İşlemi
        private static string sayfaNoOlustur(NameValueCollection queryString, int sayfaGosterim)
        {

            if (ToplamKayit <= sayfaGosterim)
            {
                return " ";
            }

            int SayfaNo = 0;

            #region varolan query strin alma işlemi
            int a, b;
            StringBuilder queryParam = new StringBuilder();
            queryParam.Append("?");


            NameValueCollection linkParametre = queryString;

            String[] dizi_1 = linkParametre.AllKeys;

            for (a = 0; a < dizi_1.Length; a++)
            {
                if (dizi_1[a].ToString() != "Sayfa")
                {
                    queryParam.Append(HttpContext.Current.Server.HtmlEncode(dizi_1[a]));

                    String[] dizi_2 = linkParametre.GetValues(dizi_1[a]);
                    for (b = 0; b < dizi_2.Length; b++)
                    {
                        queryParam.Append("=" + HttpContext.Current.Server.HtmlEncode(dizi_2[b]) + "&");
                    }
                }
                else
                {
                    String[] dizi_3 = linkParametre.GetValues(dizi_1[a]);
                    for (b = 0; b < dizi_3.Length; b++)
                    {
                        SayfaNo = Convert.ToInt32(dizi_3[b]);
                    }
                }

            }
            #endregion

            int ToplamSayfaSayisi = 0;

            StringBuilder sb = new StringBuilder();

            if (ToplamKayit % sayfaGosterim == 0)
            {
                ToplamSayfaSayisi = ToplamKayit / sayfaGosterim;
            }
            else
            {
                ToplamSayfaSayisi = ToplamKayit / sayfaGosterim + 1;
            }


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

            string ilkYaz = null;
            string geriYaz = null;
            string ileriYaz = null;
            string sonYaz = null;

            #region İlk Sayfa ve En son Sayfa İşlemi

            if (!(ToplamSayfaSayisi <= 10))
            {
                if (SayfaNo == ToplamSayfaSayisi - 1)
                {
                    sonYaz = "<span class='Last Page' >" + Strings.LastPage +"</span>\n";
                }
                else
                {
                    sonYaz = "<a class='Last Page' href= " + queryParam.ToString() + "Sayfa=" +  Convert.ToString(ToplamSayfaSayisi - 1) + "> " + Strings.LastPage + " </a>";
                }


                if (SayfaNo == 0)
                {
                    ilkYaz = "<span class='First Page' >"+ Strings.FirstPage +" </span>\n";
                }
                else
                {
                    ilkYaz = "<a class='First Page' href= " + queryParam.ToString() + "Sayfa=0> " + Strings.FirstPage + " </a>";
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
                        sb.Append("<a class='number' href= " + queryParam.ToString() + "Sayfa=" + +(i) + ">" + (i + 1) + "</a>\n");
                    }
                }
            }

            #region Sayfa İleri Geri İşlemi
            SayfaNo = SayfaNo + 1;
            int geri = SayfaNo - 2;

            if (geri < 0)
            {
                geriYaz = "<span class='Previous Page' > "+ Strings.PreviousPage +" </span>\n";
            }
            else
            {
                geriYaz = "<a class='Previous Page' href= " + queryParam.ToString() + "Sayfa=" + geri.ToString() + "> " + Strings.PreviousPage + " </a>\n";
            }

            if (SayfaNo >= ToplamSayfaSayisi)
            {
                ileriYaz = "<span class='Next Page' > "+ Strings.NextPage +" </span>\n";
            }
            else
            {
                ileriYaz = "<a class='Next Page' href= " + queryParam.ToString() + "Sayfa=" + SayfaNo.ToString() + "> " + Strings.NextPage + " </a>\n";
            }


            #endregion

            string toplamMetin = "<div class='pageTotal' >" + Strings.TotalPage + ToplamKayit.ToString() + "</div>";
            return ilkYaz + geriYaz + sb.ToString() + ileriYaz + sonYaz + toplamMetin;
        }
        #endregion
    }
}