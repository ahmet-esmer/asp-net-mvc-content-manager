using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    //[TableName("SiteIletisim")]
    //[PrimaryKey("Id")]
    public partial class SiteIletisim
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen firma adı yazınız.")]
        public string FimaAdi { get; set; }

        [Required(ErrorMessage = "Lütfen mail adresi  yazınız.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen adres bilgilerini yazınız.")]
        public string Adres { get; set; }

        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNo { get; set; }

    }
}
