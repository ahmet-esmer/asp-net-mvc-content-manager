using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelLayer
{
   public interface IAnnouncementRepository
   {

       void Insert(Duyuru duyuru);
       IEnumerable<Duyuru> FindAll();

       IEnumerable<Duyuru> PanelList(string dil);
       IEnumerable<Duyuru> FindByLang(string language);

       Duyuru FindById(int Id);
       void Delete(int id);
       void Update(Duyuru duyuru);
       void State(int id, Boolean durum);
   }
}
