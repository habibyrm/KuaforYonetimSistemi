using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KuaforYonetimSistemi.Models
{
    public class Randevu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Tarih { get; set; } // Randevu tarihi ve saati

        [Required]
        [ForeignKey("Calisan")]
        public int CalisanId { get; set; }
        public Calisan Calisan { get; set; }

        [Required]
        [ForeignKey("Islem")]
        public int IslemId { get; set; }
        public Islem Islem { get; set; }

        [Required]
        [ForeignKey("Kullanici")]
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public decimal Kazanc { get; set; } // İşlemden elde edilen kazanç
        public int IslemSuresi { get; set; } // İşlem süresi (dakika)

        [Required]
        [StringLength(50)]
        public string Durum { get; set; } = "Beklemede"; // Varsayılan: Beklemede (Onaylandı, Reddedildi)
    }
}
