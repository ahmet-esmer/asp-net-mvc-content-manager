using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;

namespace RepositoryLayer
{
     public class MailInfoRepository : IMailInfoRepository
    {
        public void Update(MailBilgi mailBilgi)
        {
            try
            {
                using (Database db = new Database())
                {
                    MailBilgi m = db.SingleOrDefault<MailBilgi>("SELECT * FROM MailBilgi WHERE Id=1");
                    m.Mail = mailBilgi.Mail;
                    m.Password = mailBilgi.Password;
                    m.Username = mailBilgi.Username;
                    m.Port = mailBilgi.Port;
                    m.SMTPClient = mailBilgi.SMTPClient;
                    db.Update(m);
                }
            }
            catch (Exception )
            {
                throw;
            }
        }

        public MailBilgi Get()
        {
            using (Database db = new Database())
            {
                return db.SingleOrDefault<MailBilgi>("SELECT * FROM MailBilgi WHERE Id=1");
            }
        }
    }
}
