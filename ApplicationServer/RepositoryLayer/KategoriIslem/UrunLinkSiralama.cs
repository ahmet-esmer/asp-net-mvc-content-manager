using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;
using ModelLayer.ModelView;
using BusinessLayer;

namespace RepositoryLayer
{
    public class UrunLinkSiralama
    {
        //private List<UrunLinkModel> toplam = new List<UrunLinkModel>();
        //private IEnumerable<UrunLinkModel> toplamGelen = new List<UrunLinkModel>();

        //public List<UrunLinkModel> KategoriSirala(IEnumerable<UrunLinkModel> basliklar)
        //{
        //    toplamGelen = basliklar;

        //    IEnumerable<UrunLinkModel> anaIcerik = from p in toplamGelen
        //                                           where p.AnaId == 0
        //                                           orderby p.Sira
        //                                           select p;

        //    foreach (UrunLinkModel p in anaIcerik)
        //    {
        //        toplam.Add(new UrunLinkModel
        //        {
        //            AnaId = p.AnaId,
        //            Sira = p.Sira,
        //            IcBaslikId = p.IcBaslikId,
        //            IcBaslik = p.IcBaslik,
        //            Link = LinkBuldingServis.Content(p.IcBaslik, p.Link, p.Dil, p.IcBaslikId),
        //            Dil = p.Dil,
        //            Serial = p.Serial,
        //            KatId = p.KatId

        //        });

        //        AltKategori(p.KatId);
        //    }

        //    return toplam;
        //}

        //private void AltKategori(int katId)
        //{
        //    IEnumerable<UrunLinkModel> altKategori = from p in toplamGelen
        //                                             where p.AnaId == katId
        //                                             orderby p.Sira
        //                                             select p;

        //    if (altKategori == null)
        //        return;

        //    foreach (UrunLinkModel p in altKategori)
        //    {
        //        toplam.Add(new UrunLinkModel
        //        {
        //            AnaId = p.AnaId,
        //            Sira = p.Sira,
        //            IcBaslikId = p.IcBaslikId,
        //            IcBaslik = p.IcBaslik,
        //            Link = UrunLink(p),
        //            Dil = p.Dil,
        //            Serial = p.Serial,
        //            KatId = p.KatId,
        //            UrunLink = p.UrunLink
        //        });

        //        AltKategori(p.KatId);
        //    }

        //}

        //public static string UrunLink(UrunLinkModel p)
        //{
        //    if (p.UrunLink == 0)
        //    {
        //        return string.Format("~/{0}/UrunDetay/{1}/{2}",
        //            p.Dil, UrlTRKarekter.Replace(p.IcBaslik), p.IcBaslikId);
        //    }
        //    else
        //    {
        //        return string.Format("~/{0}/Urunler/{1}/{2}",
        //            p.Dil, UrlTRKarekter.Replace(p.IcBaslik), p.IcBaslikId);
        //    }
        //}

    }
}
