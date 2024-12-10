using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KuaforYonetimSistemi.Models
{
    public class CalisanIslem
    {
        [Key] // Birincil Anahtar
        public int Id { get; set; }

        // Çalışan ve İşlem Foreign Key'ler
        [ForeignKey("Calisan")]
        public int CalisanId { get; set; }
        public Calisan Calisan { get; set; }

        [ForeignKey("Islem")]
        public int IslemId { get; set; }
        public Islem Islem { get; set; }
    }
}
