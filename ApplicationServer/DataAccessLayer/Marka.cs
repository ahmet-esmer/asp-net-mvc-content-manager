using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public partial class Marka
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen marka adı giriniz.")]
        public string MarkaAdi { get; set; }
        public bool Disbrutor { get; set; }
        public bool Durum { get; set; }
        public int Sira { get; set; }
    }
}
