using System;

namespace ModelLayer
{
    [TableName("HataMesaji")]
    [PrimaryKey("Id")]
    public class HataMesaji
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Mesaj { get; set; }
        public int Toplam { get; set; }
        public DateTime Tarih { get; set; }
    }
}
