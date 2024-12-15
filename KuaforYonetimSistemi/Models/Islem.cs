using System.ComponentModel.DataAnnotations;

namespace KuaforYonetimSistemi.Models
{
    public class Islem
    {
        public int Id { get; set; }
        [Required]
        public string Ad { get; set; }
        [Required]
        public decimal Ucret { get; set; }
        [Required]
        public int Sure { get; set; } // Süre (dakika cinsinden)

        // İşleme ait çalışan ilişkileri
        public ICollection<CalisanIslem> CalisanIslemler { get; set; }
    }
}
