using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;

namespace RepositoryLayer
{
    public class ImageRepository : IImageRepository
   {

       public void Insert(Resim resim)
       {
           using (Database db = new Database())
           {
               db.Insert("Resim", "Id", resim);
           }
       }

       public IEnumerable<Resim> FindBanner(string parametre, string dil)
       {
           using (Database db = new Database())
           {
               string query = "SELECT Adi, Baslik FROM Resim WHERE parametre=@0 AND Dil=@1 ORDER BY Sira";
               return db.Query<Resim>(query, parametre, dil);
           }
       }

       public IEnumerable<Resim> FindAll(string prm1, string prm2)
       {
           using (Database db = new Database())
           {
               string query = "SELECT Id , Adi,Sira, Baslik, Durum, Dil, Parametre FROM Resim WHERE parametre in(@0,@1) ORDER BY Parametre, Sira";
               return db.Query<Resim>(query, prm1,prm2);
           }
       }

       public IEnumerable<Resim> FindAll(int genelId, string parametre)
       {
           using (Database db = new Database())
           {
               string query = "SELECT Id, Adi, Sira, Baslik FROM Resim WHERE GenelId=@0 AND parametre=@1 ORDER BY Sira";
               return db.Query<Resim>(query, genelId, parametre);
           }
       }

       public Resim FindById(int Id)
       {
           using (Database db = new Database())
           {
               string query = "SELECT Id , Adi,Sira, Baslik, Durum, Dil, GenelId, Parametre FROM Resim WHERE Id=@0";

               return db.SingleOrDefault<Resim>(query, Id);
           }
       }

       public void Delete(int id)
       {
           using (Database db = new Database())
           {
               db.Execute("DELETE FROM  Resim  WHERE Id=@0", id);
           }
       }

       public void Update(Resim resim)
       {
           using (Database db = new Database())
           {
               //Resim d = db.SingleOrDefault<Resim>("SELECT * FROM Resim WHERE Id=@0", resim.Id);
               //d.Baslik = resim.Baslik;
               //d.Dil = resim.Dil;
               //d.Durum = resim.Durum;
               //d.Adi = resim.Adi;
               //d.Parametre = resim.Parametre;
               //d.Sira = resim.Sira;

               db.Update(resim);
           }
       }

       public void State(int id, bool durum)
       {
           throw new NotImplementedException();
       }

   }
}
