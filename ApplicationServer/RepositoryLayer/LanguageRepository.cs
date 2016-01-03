using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;

namespace RepositoryLayer
{
    public class LanguageRepository : ILanguageRepository
    {
        public void Insert(SiteDil siteDil)
        {
            using (Database db = new Database())
            {
              db.Insert("SiteDil","Id", siteDil);

              int id = siteDil.Id;
            }
        }

        public IEnumerable<SiteDil> FindAll()
        {
            using (Database db = new Database())
            {
                return db.Query<SiteDil>("SELECT Id, Adi, Kodu, Icon, Durum FROM SiteDil");
            }
        }

        public IEnumerable<SiteDil> FindDropDownList()
        {
            using (Database db = new Database())
            {
               List<SiteDil> liste = new List<SiteDil>();
               liste.Add(new SiteDil { Kodu= " ",  Adi = "-- Kategori Seçiniz --" });

               string  query = "SELECT Adi, Kodu FROM SiteDil";

               foreach (SiteDil b in db.Query<SiteDil>(query))
               {
                   liste.Add(new SiteDil
                   {
                       Kodu = b.Kodu,
                       Adi = b.Adi
                   });
               }

               return liste;
            }
        }


        public void Delete(int id)
        {
            using (Database db = new Database())
            {
                db.Delete<SiteDil>("WHERE Id=@0", id);
            }
        }

        public void State(int id, Boolean durum)
        {
            using (Database db = new Database())
            {
                db.Execute("UPDATE SiteDil SET durum=@0 WHERE Id=@1", Convert.ToInt16(!durum), id);
            }
        }


      
    }
}
