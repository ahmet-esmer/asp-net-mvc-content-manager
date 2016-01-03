using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{

    public class Icerik
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen sayfa başlık alanını doldurunuz.")]
        public string IcBaslik { get; set; }

        [Required(ErrorMessage="Lütfen sayfa başlık seçiniz." )]
        public int BaslikId { get; set; }

        [Required(ErrorMessage = "Lütfen sayfa Title alanını doldurunuz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen sayfa Description alanını doldurunuz.")]
        public string Description {get; set;}

        [Required(ErrorMessage = "Lütfen sayfa Keywords alanını doldurunuz.")]
        public string Keywords { get; set; }

        //[Required(ErrorMessage = "Lütfen sayfa dili seçiniz doldurunuz.")]
        public string Dil { get; set; }

        public string SayfaIcerik { get; set; }
        public string Brosur { get; set; }
        public string Link { get; set; }
        public string Target { get; set; }
        public Boolean Durum { get; set; }
        
    }
}
