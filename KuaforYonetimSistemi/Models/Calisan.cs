using System.ComponentModel.DataAnnotations;

namespace KuaforYonetimSistemi.Models
{
    public class Calisan
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        [Required]
        public string UygunSaatler { get; set; }

        // Çalışanın ilişkili işlemleri
        public ICollection<CalisanIslem> CalisanIslemler { get; set; }
    }
}
