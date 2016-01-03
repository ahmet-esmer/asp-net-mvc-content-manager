using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer.ModelView;

namespace ModelLayer
{

   public interface IContentTitleRepository
   {
       int Insert(IcerikBaslik icerikBaslik);
       IEnumerable<IcerikBaslik> FindAll(string dil);

       IEnumerable<UstMenuModel> PageLink(string dil, string GosterimAlani);
       IEnumerable<UrunLinkModel> UrunLink(string dil, int id);
       IEnumerable<UrunLinkModel> UrunLink(string dil);

       IList<IcerikBaslik> FindDropDownList();
       IcerikBaslik FindById(int Id);
       void Delete(string serial);
       void State(string serial, Boolean durum);
       void Siralama(int  id, int sira);
   }
}
