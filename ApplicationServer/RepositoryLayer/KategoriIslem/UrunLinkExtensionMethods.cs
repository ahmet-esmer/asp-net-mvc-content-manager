using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;
using ModelLayer.ModelView;
using BusinessLayer;

namespace RepositoryLayer
{
    public static class UrunLinkExtensionMethods
    {
       private static List<UrunLinkModel> siraliListe;
       private static IEnumerable<UrunLinkModel> altKategori;
       private static IEnumerable<UrunLinkModel> anaIcerik;
       private static IEnumerable<UrunLinkModel> toplamGelen;

       public static List<UrunLinkModel> KategoriSirala(this IEnumerable<UrunLinkModel> basliklar)
       {
           siraliListe = new List<UrunLinkModel>();

           toplamGelen = basliklar;
        
           anaIcerik = from p in basliklar where p.AnaId == 0 orderby p.Sira  select p ;

            foreach (UrunLinkModel p in anaIcerik)
            {
                siraliListe.Add(new UrunLinkModel
                {
                    AnaId = p.AnaId,
                    Sira = p.Sira,
                    IcBaslikId = p.IcBaslikId,
                    IcBaslik = p.IcBaslik,
                    Link = LinkBuldingServis.Content(p.IcBaslik, p.Link, p.Dil, p.IcBaslikId),
                    Dil = p.Dil,
                    Serial = p.Serial,
                    KatId = p.KatId
                });

                AltKategori(p.KatId);
            }

            return siraliListe;
        }

       private static void AltKategori(int katId)
        {
            altKategori = from p in toplamGelen where p.AnaId == katId orderby p.Sira select p;

           if (altKategori == null)
                return;

            foreach (UrunLinkModel p in altKategori)
            {
                siraliListe.Add(new UrunLinkModel
                {
                    AnaId = p.AnaId,
                    Sira = p.Sira,
                    IcBaslikId = p.IcBaslikId,
                    IcBaslik =  p.IcBaslik,
                    Link = UrunLink(p),
                    Dil = p.Dil,
                    Serial = p.Serial,
                    KatId = p.KatId,
                    UrunLink = p.UrunLink
                });

                AltKategori(p.KatId);
            }    
          
        }

       public static string UrunLink(UrunLinkModel p)
        {
            if (p.UrunLink == 0)
            {
                return string.Format("~/{0}/UrunDetay/{1}/{2}",
                    p.Dil, UrlTRKarekter.Replace(p.IcBaslik), p.IcBaslikId);
            }
            else
            {
                return string.Format("~/{0}/Urunler/{1}/{2}",
                    p.Dil, UrlTRKarekter.Replace(p.IcBaslik), p.IcBaslikId);
            }
        }

    }
}
