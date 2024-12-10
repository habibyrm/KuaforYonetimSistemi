namespace KuaforYonetimSistemi.Models
{
    public class Islem
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Ucret { get; set; }
        public int Sure { get; set; } // Süre (dakika cinsinden)

        // İşleme ait çalışan ilişkileri
        public ICollection<CalisanIslem> CalisanIslemler { get; set; }
    }
}
