using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Kategori
    {
        public int Id { get; set; }
        public int AnaId { get; set; }
        public int Sira { get; set; }
        public string Serial { get; set; }
        [Required(ErrorMessage = "Kategori Adı Seçiniz.")]
        [Display(Name = "Kategori Adı")]
        public string Kategoriadi { get; set; }

        [Required(ErrorMessage = "Title alanını doldurunuz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description alanını doldurunuz.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Keywords alanını doldurunuz.")]
        public string Keywords { get; set; }

        public bool Durum { get; set; }

    }
}
