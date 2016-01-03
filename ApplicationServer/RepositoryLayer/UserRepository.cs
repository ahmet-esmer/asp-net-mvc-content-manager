using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;


namespace RepositoryLayer
{
    public class UserRepository : IUserRepository
    {

        public Kullanici Login(string ePosta, string sifre)
        {
            using (Database db = new Database())
            {
                db.EnableAutoSelect = false;
                string query = "SELECT Id, AdiSoyadi, EPosta " +
                         "FROM Kullanici WHERE EPosta=@0 AND Sifre=@1";

                return db.SingleOrDefault<Kullanici>(query, ePosta, sifre);
            }
        }

        public void Insert(Kullanici kullanici)
        {
            using (Database db = new Database())
            {
                db.Insert("Kullanici","Id", kullanici);
            } 
        }

        public IEnumerable<Kullanici> FindAll()
        {
            using (Database db = new Database())
            {
                return db.Query<Kullanici>("SELECT Id, AdiSoyadi, EPosta, Sifre FROM Kullanici");
            }
        }

        public Kullanici FindById(int Id)
        {
            throw new NotImplementedException();
        }



        public void Delete(int id)
        {
            using (Database db = new Database())
            {
                db.Delete<Kullanici>("WHERE Id=@0", id);
            }
        }
    }
}
