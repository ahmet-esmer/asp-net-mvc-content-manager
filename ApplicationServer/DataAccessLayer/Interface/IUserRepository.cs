using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelLayer
{
    public  interface IUserRepository
    {
        Kullanici Login(string ePosta, string sifre);
        void Insert(Kullanici kullanici);
        IEnumerable<Kullanici> FindAll();
        Kullanici FindById(int Id);
        void Delete(int id);
    }
}
