using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public partial class Urun
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen title alanını doldurunuz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen description alanını doldurunuz.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Lütfen keyword alanını doldurunuz.")]
        public string Keywords { get; set; }

        [Required(ErrorMessage = "Lütfen marka seçiniz.")]
        public int MarkaId { get; set; }

        public string UrunKodu { get; set; }

        [Required(ErrorMessage = "Lütfen ürün adı giriniz.")]
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public string Ozellik { get; set; }
        public int Sira { get; set; }
        public bool Durum { get; set; }

    }
}
