using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using MicroOptik.WebUI.Infrastructure.Attribute;

namespace MicroOptik.WebUI.Models
{
    public class IletisimFormu
    {

        [Required(ErrorMessageResourceType = typeof(Resources.ContactForm),
            ErrorMessageResourceName = "RegAdSoyad")]
        public string AdSoyad { get; set; }



        [Required(ErrorMessageResourceType = typeof(Resources.ContactForm),
           ErrorMessageResourceName = "RegFirmaAdi")]
        public string FiramaAdi { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources.ContactForm),
           ErrorMessageResourceName = "RegTelefon")]
        public string Telefon { get; set; }

        [Email(ErrorMessageResourceType = typeof(Resources.ContactForm), 
            ErrorMessageResourceName = "RegEpostaGec")]
        [Required(ErrorMessageResourceType = typeof(Resources.ContactForm),
           ErrorMessageResourceName = "RegEposta")]
        public string Eposta { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources.ContactForm),
           ErrorMessageResourceName = "RegMesaj")]
        public string Mesaj { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources.ContactForm),
          ErrorMessageResourceName = "RegCaptcha")]
        public string Captcha { get; set; }
       
    }
}