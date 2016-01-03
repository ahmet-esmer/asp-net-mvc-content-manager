using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;

namespace RepositoryLayer
{
    public class KategoriListExtensionMethods
    {
        //List<IcerikBaslik> toplam = new List<IcerikBaslik>();
        //List<IcerikBaslik> toplamGelen = new List<IcerikBaslik>();

        //public List<IcerikBaslik> KategoriSirala(List<IcerikBaslik> basliklar)
        //{
        //    toplamGelen = basliklar;

        //    IEnumerable<IcerikBaslik> anaIcerik = from p in toplamGelen where p.AnaId == 0 select p;

        //    foreach (IcerikBaslik p in anaIcerik)
        //    {
        //        toplam.Add(new IcerikBaslik { Id = p.Id, KategoriAdi = p.KategoriAdi });
        //        AltKategori(p.Id);
        //    }

        //    return toplam;
        //}

        //private void AltKategori(int katId)
        //{
        //    IEnumerable<IcerikBaslik> altKategori = from p in toplamGelen where p.AnaId == katId select p;

        //    if (altKategori == null)
        //        return;

        //    foreach (IcerikBaslik p in altKategori)
        //    {
        //        toplam.Add(new IcerikBaslik { Id = p.Id, KategoriAdi = "--" + p.KategoriAdi });
        //        AltKategori(p.Id);
        //    }

        //}
    }
}
