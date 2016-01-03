using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MailLibrary;

namespace MailLibrary
{
    public class MailManager
    {

        private Mail instanceMail;
        private static MailManager instance;
        private delegate void MailSendUserHandler(string toMail, string title, string content);
        private delegate void MailSendAdminHandler(string title, string content);


        private MailManager()
        {
            instanceMail = new Mail();
        }

        public static MailManager Admin
        {
            get
            {
                if (instance == null)
                {
                    lock (new object())
                    {
                        if (instance == null)
                            instance = new MailManager();
                    }
                }
                return instance;
            }
        }
        public static MailManager User
        {
            get
            {
                if (instance == null)
                {
                    lock (new object())
                    {
                        if (instance == null)
                            instance = new MailManager();
                    }
                }
                return instance;
            }
        }
  

        public void Send(string title, string content, ProcessType type = ProcessType.Normal)
        {
            if (type == ProcessType.Normal)
            {
                instanceMail.Send(title, content);
            }
            else
            {
                MailSendAdminHandler sendAdmin = new MailSendAdminHandler(instanceMail.Send);
                sendAdmin.BeginInvoke(title, content, null, null);
            }
        }

        public void Send(string toMail, string title, string content, ProcessType type = ProcessType.Normal)
        {
            if (instanceMail != null)
            {
                if (type == ProcessType.Normal)
                {
                    instanceMail.Send(toMail, title, content);
                }
                else
                {
                    MailSendUserHandler sendUser = new MailSendUserHandler(instanceMail.Send);
                    sendUser.BeginInvoke(toMail, title, content, null, null);
                }
                
            }
        }

    }
}
