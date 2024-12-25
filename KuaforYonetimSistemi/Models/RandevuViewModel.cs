namespace KuaforYonetimSistemi.Models
{
    public class RandevuViewModel
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public string CalisanAdi { get; set; }
        public string IslemAdi { get; set; }
        public decimal Kazanc { get; set; }
        public int IslemSuresi { get; set; }
        public string Durum { get; set; }
    }
}
