using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace MicroOptik.WebUI.Models
{
    public class Login 
    {

        [Required(ErrorMessage = "Lütfen E-Posta alanını doldurunuz.")]
        [Email(ErrorMessage = "Geçersiz mail adresi")]
        public string EPosta { get; set; }


        [StringLength(10, ErrorMessage = "Şifreniz 4 ile 10 karakter aralığında olmalıdır.", MinimumLength = 4)]
        [Display(Name="Şifre")]
        [Required(ErrorMessage = "Lütfen şifre giriniz.")]
        public string Sifre { get; set; }

    }
}
