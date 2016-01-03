using System;
using System.Linq;
using System.Xml.Linq;
using ConfigLibrary;
using LoggerLibrary.Abstract;

namespace LoggerLibrary
{
    public class LogManager
    {
        private LoggerBase headLogger;
        private LoggerBase tailLogger;
        private static string location = null;
        private static LogManager instance, instanceMail, instanceText, instanceEvent, instanceDB;

        public static LogManager Default
        {
            get
            {
                if (instance == null)
                {
                    lock (new object())
                    {
                        if (instance == null)
                            instance = new LogManager();
                    }
                }

                return instance;
            }
        }
        public static LogManager Mail
        {
            get
            {
                location = "MailLogger";

                if (instanceMail == null)
                {
                    lock (new object())
                    {
                        if (instanceMail == null)
                            instanceMail = new LogManager();
                    }
                }

                return instanceMail;
            }
        }
        public static LogManager Text
        {
            get
            {
                location = "TextLogger";

                if (instanceText == null)
                {
                    lock (new object())
                    {
                        if (instanceText == null)
                            instanceText = new LogManager();
                    }
                }
                return instanceText;
            }
        }
        public static LogManager Event
        {
            get
            {
                location = "EventLogger";

                if (instanceEvent == null)
                {
                    lock (new object())
                    {
                        if (instanceEvent == null)
                            instanceEvent = new LogManager();
                    }
                }

                return instanceEvent;
            }
        }
        public static LogManager SqlDB
        {
            get
            {
                location = "DbLogger";

                if (instanceDB == null)
                {
                    lock (new object())
                    {
                        if (instanceDB == null)
                            instanceDB = new LogManager();
                    }
                }

                return instanceDB;
            }
        }


        private LogManager()
        {
            ReadConfig();
        }

        private void ReadConfig()
        {

            XElement doc = XElement.Load(ConfigHelper.GetPhysicalPath(@"Config\LogConfig.xml"));

            var loggers = from p in doc.Elements("loggerClass")
                          orderby p.Value == location descending
                          select new
                          {
                              Class = p.Value,
                          };

            foreach (var logger in loggers)
            {
                LoggerBase logInstance = LogFactory.GetInstens(logger.Class);

                if (headLogger == null)
                    headLogger = logInstance;

                if (tailLogger != null)
                    tailLogger.NextLogger = logInstance;

                tailLogger = logInstance;
            }
        }

        public void Write(string baslik, string mesaj)
        {
            if (headLogger != null)
            {
                Action<string, string> logStrHandler = new Action<string, string>(headLogger.Write);
                logStrHandler.BeginInvoke(baslik, mesaj, null, null);
            }
        }

        public void Write(string baslik, Exception mesaj)
        {
            if (headLogger != null)
            {
                Action<string, Exception> logStrExHandler = new Action<string, Exception>(headLogger.Write);
                logStrExHandler.BeginInvoke(baslik, mesaj, null, null);
            }
        }

        public void Write(Exception mesaj)
        {
            if (headLogger != null)
            {
                Action<Exception> logExHandler = new Action<Exception>(headLogger.Write);
                logExHandler.BeginInvoke(mesaj, null, null);
            }
        }


    }
}
