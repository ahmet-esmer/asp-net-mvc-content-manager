using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelLayer
{

   public interface IImageRepository
   {
       void Insert(Resim resim);
       IEnumerable<Resim> FindAll(int genelId, string parametre);
       IEnumerable<Resim> FindAll(string prm1, string prm2);
       IEnumerable<Resim> FindBanner(string parametre, string dil);

       Resim FindById(int Id);
       void Delete(int id);
       void Update(Resim resim);
       void State(int id, Boolean durum);
   }
}
