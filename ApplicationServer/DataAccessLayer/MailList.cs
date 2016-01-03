using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace ModelLayer.Entites
{
    public partial class MailList
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen ad soyadı yazını.")]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; }


        [Required(ErrorMessage = "Lütfen mail adresi giriniz.")]
        [Email(ErrorMessage = "Lütfen geçerli mail adresi giriniz.")]
        [Display(Name = "Mail Adresi")]
        public string Mail { get; set; }

        public DateTime PostaTarih { get; set; }


       
    }
}
