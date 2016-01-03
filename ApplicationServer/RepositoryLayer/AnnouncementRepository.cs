using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;

namespace RepositoryLayer
{
   public class AnnouncementRepository : IAnnouncementRepository
    {

        public void Insert(Duyuru duyuru)
        {
            duyuru.Tarih = DateTime.Now;
            using (Database db = new Database())
            {
                db.Insert("Duyuru", "Id", duyuru);
            }
        }

        public IEnumerable<Duyuru> FindByLang(string language)
        {
            using (Database db = new Database())
            {
                return db.Query<Duyuru>("SELECT Id, Baslik, Icerik, Tarih,Dil, Durum FROM Duyuru WHERE Dil=@0 ORDER BY Tarih DESC", language);
            }
        }

        public IEnumerable<Duyuru> PanelList(string dil)
        {
            using (Database db = new Database())
            {
                return db.Query<Duyuru>("SELECT TOP(6) Id, Baslik, Icerik, Dil FROM Duyuru WHERE Dil=@0 ORDER BY Tarih DESC", dil);
            }
        }

        public IEnumerable<Duyuru> FindAll()
        {
            using (Database db = new Database())
            {
                return db.Query<Duyuru>("SELECT Id, Baslik, Icerik, Tarih,Dil, Durum FROM Duyuru");
            }
        }

        public Duyuru FindById(int Id)
        {
            using (Database db = new Database())
            {
                db.EnableAutoSelect = false;
                string query = "SELECT Id, Baslik, Icerik, Tarih,Dil, Durum FROM Duyuru WHERE Id=@0";
                return db.SingleOrDefault<Duyuru>(query, Id.ToString());  
            }
        }

        public void Delete(int id)
        {
            using (Database db = new Database())
            {
                db.Execute("DELETE FROM  Duyuru  WHERE Id=@0",  id);
            }
        }

        public void Update(Duyuru duyuru)
        {
            using (Database db = new Database())
            {
                Duyuru d = db.SingleOrDefault<Duyuru>("SELECT * FROM Duyuru WHERE Id=@0", duyuru.Id);
                d.Baslik = duyuru.Baslik;
                d.Dil = duyuru.Dil;
                d.Durum = duyuru.Durum;
                d.Icerik = duyuru.Icerik;

                db.Update(d);
            }
        }

        public void State(int id, bool durum)
        {
            using (Database db = new Database())
            {
                db.Execute("UPDATE Duyuru SET durum=@0 WHERE Id=@1", Convert.ToInt16(!durum), id);
            }
        }

    }
}
