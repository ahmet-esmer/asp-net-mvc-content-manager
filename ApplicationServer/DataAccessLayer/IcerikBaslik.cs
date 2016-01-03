using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class IcerikBaslik
    {
        public int Id { get; set; }
        public int AnaId { get; set; }

        [Required(ErrorMessage = "Lütfen  kategori adi adresi yazını.")]
        public string KategoriAdi { get; set; }

        public string Serial { get; set; }
        public Boolean Durum { get; set; }
        public Boolean Urun { get; set; }
        public int Sira { get; set; }
        public string GosterimAlani { get; set; }
        public string IcBaslik { get; set; }
    }
}
