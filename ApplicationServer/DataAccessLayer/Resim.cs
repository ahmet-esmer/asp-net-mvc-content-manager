using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace ModelLayer
{
    public partial class Resim
    {
        public int Id { get; set; }
        public int GenelId { get; set; }

        [Required(ErrorMessage = "Lütfen gösterim alanı seçiniz.")]
        public string Parametre { get; set; }

        
        [Required(ErrorMessage = "Lütfen resim seçiniz.")]
        [Display(Name = "Resim")]
        [FileExtensions("png|jpg|jpeg|gif", ErrorMessage = "Dosya uzantsı png, jpg, jpeg, veya gif olmalıdır. ")]
        public string Adi { get; set; }

        [Display(Name = "Resim Başlik")]
        [Required(ErrorMessage = "Lütfen resim başlığı giriniz.")]
        public string Baslik { get; set; }

        [Required(ErrorMessage = "Lütfen gösterim sırası giriniz.")]
        [Display(Name = "Gösterim Sırası")]
        [Min(1,ErrorMessage="Resim gösterim sirası 1 den yüksek olmalıdır.")]
        [Integer(ErrorMessage="Lütfen sayısal deger giriniz")]
        public int Sira { get; set; }

        [Display(Name = "Gösterim Dili")]
        public string Dil { get; set; }
        public bool Durum { get; set; }
    }
}
