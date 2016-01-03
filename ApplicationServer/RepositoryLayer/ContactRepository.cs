using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;
using BusinessLayer;

namespace RepositoryLayer
{
   public class ContactRepository : IContactRepository
    {
       public void Update(SiteIletisim iletisim)
        {
            try
            {
                using (Database db = new Database())
                {
                    SiteIletisim i = db.SingleOrDefault<SiteIletisim>("SELECT * FROM SiteIletisim WHERE Id=@0", 1);
                    i.Mail = iletisim.Mail;
                    i.Telefon = iletisim.Telefon;
                    i.VergiDairesi = iletisim.VergiDairesi;
                    i.VergiNo = iletisim.VergiNo;
                    i.Faks = iletisim.Faks;
                    i.FimaAdi = iletisim.FimaAdi;
                    i.Adres =  GenelFonksiyonlar.EnterDonusturBr(iletisim.Adres);

                    db.Update(i);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

       public SiteIletisim Get()
       {
           using (Database db = new Database())
           {
               return db.SingleOrDefault<SiteIletisim>("SELECT * FROM SiteIletisim WHERE Id=@0", 1);
           }
        }
    }
}
