using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer.ModelView;

namespace ModelLayer
{
   public interface IContentRepository
   {
       void Insert(Icerik icerik);
       Icerik FindById(int Id, string dil);
       Icerik FindByActionName(string dil, string action);
       Icerik FindByIcerikId(int Id);
       void Update(Icerik icerik);

       IEnumerable<UrunListeModel> ProductList(PagingModel page);
       int ProductListCount(PagingModel page);

       IEnumerable<UrunListeModel> ProductSearchList(PagingModel page);
       int ProductSearchCount(PagingModel page);
   }
}
