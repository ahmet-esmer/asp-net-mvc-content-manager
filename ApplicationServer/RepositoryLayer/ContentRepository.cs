using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;
using ModelLayer.ModelView;

namespace RepositoryLayer
{
    public class ContentRepository :IContentRepository
    {
       
        public void Insert(Icerik icerik)
        {
            using (Database db = new Database())
            {
                db.Insert("Icerik", "Id", icerik);
            }
        }

        public void Update(Icerik icerik)
        {
            using (Database db = new Database())
            {
                db.Update("Icerik", "Id", icerik);
            }
        }

        public Icerik FindById(int Id, string dil)
        {
            using (Database db = new Database())
            {
                db.EnableAutoSelect = false;

                var sql = Sql.Builder
                 .Select("Id,BaslikId,IcBaslik,Title,Description,Keywords,SayfaIcerik,Brosur,Link,Target,Dil,Durum")
                 .From("Icerik")
                 .Where("BaslikId=@0 AND Dil=@1", Id, dil);

                return db.SingleOrDefault<Icerik>(sql);
            }
        }

        public Icerik FindByIcerikId(int Id)
        {

                using (Database db = new Database())
                {
                    db.EnableAutoSelect = false;

                    var sql = Sql.Builder
                     .Select("Id,BaslikId,IcBaslik,Title,Description,Keywords,SayfaIcerik,Brosur,Link,Target,Dil,Durum")
                     .From("Icerik")
                     .Where("Id=@0 AND Durum=1", Id);

                   return db.SingleOrDefault<Icerik>(sql);
                }
        }

        public Icerik FindByActionName(string dil, string action)
        {
            using (Database db = new Database())
            {
                db.EnableAutoSelect = false;

                var sql = Sql.Builder
                 .Select("Id,BaslikId,IcBaslik,Title,Description,Keywords,SayfaIcerik,Brosur,Link,Target,Dil,Durum")
                 .From("Icerik")
                 .Where("Link=@0 AND Dil=@1", action, dil);

                return db.SingleOrDefault<Icerik>(sql);
            }
        }

        public IEnumerable<UrunListeModel> ProductList(PagingModel page)
        {
            using (Database db = new Database())
            {
                db.EnableAutoSelect = false;

                var s = Sql.Builder.Append("exec sp_IcerikUrunListe ");
                s.Append("  @@baslangic = @0", page.StartItem);
                s.Append(", @@bitis = @0", page.EndItem);
                s.Append(", @@icBaslikId = @0", page.IcBaslikId);
                s.Append(", @@dil = @0", page.Culture);

                return db.Query<UrunListeModel>(s);
            }
        }

        public int ProductListCount(PagingModel page)
        {
            using (Database db = new Database())
            {
                db.EnableAutoSelect = false;

                var s = Sql.Builder.Append("exec sp_IcerikUrunNo");
                s.Append("  @@icBaslikId = @0", page.IcBaslikId);
                s.Append(", @@dil = @0", page.Culture);

                return db.ExecuteScalar<int>(s);
            }
        }

        public IEnumerable<UrunListeModel> ProductSearchList(PagingModel page)
        {
            using (Database db = new Database())
            {
                db.EnableAutoSelect = false;

                var s = Sql.Builder.Append("exec sp_IcerikUrunSearch");
                s.Append("  @@baslangic = @0", page.StartItem);
                s.Append(", @@bitis = @0", page.EndItem);
                s.Append(", @@searchKey = @0", page.SearchKey);
                s.Append(", @@dil = @0", page.Culture);

                return db.Query<UrunListeModel>(s);
            }
        }

        public int ProductSearchCount(PagingModel page)
        {
            using (Database db = new Database())
            {
                db.EnableAutoSelect = false;

                var s = Sql.Builder.Append("exec sp_IcerikSearchNo");
                s.Append("  @@searchKey = @0", page.SearchKey);
                s.Append(", @@dil = @0", page.Culture);

                return db.ExecuteScalar<int>(s);
            }
        }
    }
}
