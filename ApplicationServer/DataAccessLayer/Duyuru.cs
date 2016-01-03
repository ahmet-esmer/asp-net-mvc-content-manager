using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Duyuru
    {
        public int Id { get; set; }

        [Display(Name = "Duyuru Baslik")]
        [Required(ErrorMessage = "Duyuru Baslik giriniz")]
        public string Baslik { get; set; }

        //[Required(ErrorMessage = "Duyuru içerigi giriniz.")]
        [Display(Name = "Duyuru İçeirik")]
        public string Icerik { get; set; }

        public DateTime Tarih { get; set; }

        [Display(Name = "Gösterim Durumu")]
        public bool Durum { get; set; }

        [Required(ErrorMessage = "Lütfen Dil Seçiniz")]
        [Display(Name = "Gösterim Dili")]
        public string Dil { get; set; }

    }
}
