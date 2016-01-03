using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace ModelLayer
{

    public class SiteDil
    {
        public int Id {get; set;}

        [Required(ErrorMessage = "Lütfen Ad alanını doldurunuz.")]
        [Display(Name = "Adi:")]
        public string Adi { get; set; }

        [Required(ErrorMessage="Lütfen Dil Kodu Yazınız.")]
        [Display(Name="Dil Kodu")]
        public string Kodu { get; set; }

        [Required(ErrorMessage = "Lütfen resim seçiniz.")]
        [FileExtensions("png", ErrorMessage = "Dosya uzantsı png olmalıdır. ")]
        [Display(Name = "Icon")]
        public string Icon { get; set; }

        public bool Durum { get; set; }

    }
}
