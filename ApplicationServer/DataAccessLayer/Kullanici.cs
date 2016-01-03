using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace ModelLayer
{

    public class Kullanici
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Ad alanını doldurunuz.")]
        [StringLength(40, ErrorMessage = "Ad ve Soyadı 6 ile 40 karakter aralığında olmalıdır.", MinimumLength = 6)]
        [Display(Name = "Ad Soyad:")]
        public string AdiSoyadi { get; set; }

        [Required(ErrorMessage = "Lütfen E-Posta alanını doldurunuz.")]
        [Email(ErrorMessage = "Geçersiz mail adresi")]
        public string EPosta { get; set; }

        [StringLength(10, ErrorMessage = "Şifreniz 4 ile 10 karakter aralığında olmalıdır.", MinimumLength = 4)]
        [Required(ErrorMessage = "Lütfen şifre giriniz.")]
        public string Sifre { get; set; }
    }
}
