using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;
using BusinessLayer;
using ModelLayer.ModelView;

namespace RepositoryLayer
{
    public class ContentTitleRepository : IContentTitleRepository
    {
        public int Insert(IcerikBaslik i)
        { 
            int sonId = 0;
            using (Database db = new Database())
            {
                db.BeginTransaction();
                db.EnableAutoSelect = false;

                var s = Sql.Builder.Append("exec sp_IcerikBaslikEkle ");
                s.Append("  @@anaKategori_serial = @0", i.Serial);
                s.Append(", @@kayitId = @0", i.Id);
                s.Append(", @@kategoriAdi = @0", i.KategoriAdi);
                s.Append(", @@durum = @0", i.Durum);
                s.Append(", @@urun = @0", i.Urun);
                s.Append(", @@alan = @0", i.GosterimAlani);

                db.Execute(s);
                sonId = db.ExecuteScalar<int>("SELECT MAX(Id) FROM IcerikBaslik");
                db.CompleteTransaction(); 
            }

            return sonId;
        }

        public IEnumerable<IcerikBaslik> FindAll(string dil)
        {
            using (Database db = new Database())
            {
                string query = " SELECT B.Id, B.KategoriAdi, B.Serial, B.GosterimAlani," +
                               " B.Sira, B.Durum," +
                               " dbo.IcerikDurumBul(B.Id, @0 ) as IcBaslik" +
                               " FROM IcerikBaslik as B ORDER BY Serial, Sira";

                return db.Query<IcerikBaslik>(query,dil);
            }
        }

        public IList<IcerikBaslik> FindDropDownList()
        {
            using (Database db = new Database())
            {
                List<IcerikBaslik> baslik1 = new List<IcerikBaslik>();
                string query = "SELECT Serial, KategoriAdi FROM IcerikBaslik ORDER BY Serial, Sira";

                baslik1.Add(new IcerikBaslik { Serial = "0", KategoriAdi = "-- Kategori Seçiniz --" });

                foreach (IcerikBaslik b in db.Query<IcerikBaslik>(query))
                {
                    baslik1.Add(new IcerikBaslik
                    {
                        Serial = b.Serial,
                        KategoriAdi = KategoriServis.Cizgi(b.Serial) + b.KategoriAdi
                    }); 
                }

                return baslik1 ;
            }
        }

        public IcerikBaslik FindById(int Id)
        {
            using (Database db = new Database())
            {
                db.EnableAutoSelect = false;
                string query = "SELECT Id, AnaId, Kategoriadi, Durum, Serial, Sira, GosterimAlani,Urun FROM IcerikBaslik WHERE Id=@0";
                return db.SingleOrDefault<IcerikBaslik>(query, Id.ToString());  
            }
        }

        public void Delete(string serial )
        {
            using (Database db = new Database())
            {
                var s = Sql.Builder.Append("exec sp_IcerikBaslikSil ");
                s.Append("  @@serial = @0", serial);

                db.Execute(s);
            }
        }

        public void State(string serial, bool durum)
        {
            using (Database db = new Database())
            {
                var s = Sql.Builder.Append("exec sp_IcerikBaslıkDurum");
                s.Append("  @@serial = @0", serial);
                s.Append(", @@durum = @0", Convert.ToInt16(!durum));

                db.Execute(s);

            }
        }

        public void Siralama(int id, int sira)
        {
            using (Database db = new Database())
            {
                db.Execute("UPDATE IcerikBaslik SET Sira=@0 WHERE Id=@1", sira, id);
            }
        }

        public IEnumerable<UstMenuModel> PageLink(string dil, string GosterimAlani)
        {
            using (Database db = new Database())
            {
                List<UstMenuModel> menu = new List<UstMenuModel>();

                string query = " SELECT I.Id as IcBaslikId, I.IcBaslik, I.Dil, I.Link, I.Target" +
                               " FROM IcerikBaslik AS B" +
                               " INNER JOIN Icerik AS I ON B.Id = I.BaslikId" +
                               " WHERE B.GosterimAlani=@0 AND I.Dil=@1 AND B.Urun='0'" +
                               " AND B.Durum='1' AND B.AnaId='0' ORDER BY B.Sira";


                foreach (UstMenuModel m in db.Query<UstMenuModel>(query, GosterimAlani, dil))
                {
                    menu.Add(new UstMenuModel
                    {
                        IcBaslikId = m.IcBaslikId,
                        IcBaslik = m.IcBaslik,
                        Dil = m.Dil,
                        Link = LinkBuldingServis.Content(m.IcBaslik, m.Link, m.Dil, m.IcBaslikId),
                        Target = m.Target
                    });
                }

                return menu;
            }
        }


        /// <summary>
        /// Ana Kategori 
        /// </summary>
        public IEnumerable<UrunLinkModel> UrunLink(string dil)
        {
            using (Database db = new Database())
            {
                db.EnableAutoSelect = false;
                var sp = Sql.Builder.Append("sp_IcerikBaslikAnaListele ");
                sp.Append(" @@dil = @0", dil);
                return db.Query<UrunLinkModel>(sp);
            }
        }


        /// <summary>
        ///  Kendisine gelen id ye göre üst kategorileri ve alt kategorileri ürünleri getirir.
        /// </summary>
        public IEnumerable<UrunLinkModel> UrunLink(string dil, int id)
        {
            using (Database db = new Database())
            {
                db.EnableAutoSelect = false;
                var sp = Sql.Builder.Append("sp_IcerikBaslikListele ");
                sp.Append("  @@id = @0", id);
                sp.Append(", @@dil = @0", dil);

                return db.Query<UrunLinkModel>(sp);
            }
        }

     
    }
}
