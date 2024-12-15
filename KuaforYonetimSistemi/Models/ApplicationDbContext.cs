using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace KuaforYonetimSistemi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Calisan> Calisan { get; set; }
        public DbSet<Islem> Islem { get; set; }
        public DbSet<CalisanIslem> CalisanIslem { get; set; }
        public DbSet<Randevu> Randevu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DbKuafor;Trusted_Connection=True;MultipleActiveResultSets=true")
                .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Kazanc alanı için hassasiyet tanımlama
            modelBuilder.Entity<Randevu>()
                .Property(r => r.Kazanc)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CalisanIslem>()
                .HasOne(ci => ci.Calisan)
                .WithMany(c => c.CalisanIslemler)
                .HasForeignKey(ci => ci.CalisanId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CalisanIslem>()
                .HasOne(ci => ci.Islem)
                .WithMany(i => i.CalisanIslemler)
                .HasForeignKey(ci => ci.IslemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Islem>()
                .Property(i => i.Ucret)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Kullanici)
                .WithMany(k => k.Randevular)
                .HasForeignKey(r => r.KullaniciId)
                .OnDelete(DeleteBehavior.Cascade);

            // Randevu Durum özelliği için varsayılan değer ayarlama
            modelBuilder.Entity<Randevu>()
                .Property(r => r.Durum)
                .HasDefaultValue("Beklemede"); // Varsayılan: Beklemede

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Çalışanlar
            modelBuilder.Entity<Calisan>().HasData(
                new Calisan { Id = 1, AdSoyad = "Ayşe Yılmaz", UygunSaatler = "09:00-18:00" },
                new Calisan { Id = 2, AdSoyad = "Fatma Kaya", UygunSaatler = "10:00-17:00" },
                new Calisan { Id = 3, AdSoyad = "Elif Demir", UygunSaatler = "08:00-16:00" },
                new Calisan { Id = 4, AdSoyad = "Zehra Çelik", UygunSaatler = "12:00-20:00" },
                new Calisan { Id = 5, AdSoyad = "Gizem Arslan", UygunSaatler = "11:00-19:00" }
            );

            // İşlemler
            modelBuilder.Entity<Islem>().HasData(
                new Islem { Id = 1, Ad = "Saç Kesimi", Ucret = 250, Sure = 40 },
                new Islem { Id = 2, Ad = "Saç Boyama", Ucret = 1500, Sure = 175 },
                new Islem { Id = 3, Ad = "Fön Çekme", Ucret = 200, Sure = 20 },
                new Islem { Id = 4, Ad = "Saç Bakımı", Ucret = 820, Sure = 200 },
                new Islem { Id = 5, Ad = "Perma", Ucret = 1000, Sure = 180 },
                new Islem { Id = 6, Ad = "Manikür", Ucret = 150, Sure = 40 },
                new Islem { Id = 7, Ad = "Pedikür", Ucret = 150, Sure = 40 },
                new Islem { Id = 8, Ad = "Kaş Alma", Ucret = 50, Sure = 20 },
                new Islem { Id = 9, Ad = "Makyaj", Ucret = 250, Sure = 40 }
            );

            // Kullanıcılar
            modelBuilder.Entity<Kullanici>().HasData(
                new Kullanici { Id = 1, KullaniciAdi = "admin", Sifre = "12345", Email = "admin@example.com", Rol = "Admin" },
                new Kullanici { Id = 2, KullaniciAdi = "fatma", Sifre = "12345", Email = "fatma@example.com", Rol = "Kullanici" },
                new Kullanici { Id = 3, KullaniciAdi = "ahmet", Sifre = "12345", Email = "ahmet@example.com", Rol = "Kullanici" },
                new Kullanici { Id = 4, KullaniciAdi = "elif", Sifre = "12345", Email = "elif@example.com", Rol = "Kullanici" },
                new Kullanici { Id = 5, KullaniciAdi = "gizem", Sifre = "12345", Email = "gizem@example.com", Rol = "Kullanici" }
            );

            // Çalışan-İşlem İlişkileri
            modelBuilder.Entity<CalisanIslem>().HasData(
                new CalisanIslem { Id = 1, CalisanId = 1, IslemId = 1 },
                new CalisanIslem { Id = 2, CalisanId = 1, IslemId = 3 },
                new CalisanIslem { Id = 3, CalisanId = 1, IslemId = 6 },
                new CalisanIslem { Id = 4, CalisanId = 2, IslemId = 2 },
                new CalisanIslem { Id = 5, CalisanId = 2, IslemId = 4 },
                new CalisanIslem { Id = 6, CalisanId = 2, IslemId = 7 },
                new CalisanIslem { Id = 7, CalisanId = 3, IslemId = 1 },
                new CalisanIslem { Id = 8, CalisanId = 3, IslemId = 5 },
                new CalisanIslem { Id = 9, CalisanId = 3, IslemId = 8 },
                new CalisanIslem { Id = 10, CalisanId = 4, IslemId = 3 },
                new CalisanIslem { Id = 11, CalisanId = 4, IslemId = 9 },
                new CalisanIslem { Id = 12, CalisanId = 5, IslemId = 2 },
                new CalisanIslem { Id = 13, CalisanId = 5, IslemId = 4 },
                new CalisanIslem { Id = 14, CalisanId = 5, IslemId = 8 }
            );

            // Bugünden Başlayan ve 7 Günlük Randevular
            modelBuilder.Entity<Randevu>().HasData(
            // Bugün için
            new Randevu { Id = 6, CalisanId = 1, IslemId = 1, Tarih = DateTime.UtcNow.Date.AddHours(9), KullaniciId = 2, Kazanc = 250, IslemSuresi = 40, Durum = "Onaylandı" },
            new Randevu { Id = 7, CalisanId = 2, IslemId = 2, Tarih = DateTime.UtcNow.Date.AddHours(11), KullaniciId = 3, Kazanc = 1500, IslemSuresi = 175, Durum = "Beklemede" },
            new Randevu { Id = 8, CalisanId = 3, IslemId = 3, Tarih = DateTime.UtcNow.Date.AddHours(14), KullaniciId = 4, Kazanc = 200, IslemSuresi = 20, Durum = "Onaylandı" },
        
            // Yarın için
            new Randevu { Id = 9, CalisanId = 4, IslemId = 4, Tarih = DateTime.UtcNow.AddDays(1).Date.AddHours(10), KullaniciId = 5, Kazanc = 820, IslemSuresi = 200, Durum = "Beklemede" },
            new Randevu { Id = 10, CalisanId = 5, IslemId = 5, Tarih = DateTime.UtcNow.AddDays(1).Date.AddHours(13), KullaniciId = 2, Kazanc = 1000, IslemSuresi = 180, Durum = "Reddedildi" },
            new Randevu { Id = 11, CalisanId = 1, IslemId = 6, Tarih = DateTime.UtcNow.AddDays(1).Date.AddHours(15), KullaniciId = 3, Kazanc = 150, IslemSuresi = 40, Durum = "Onaylandı" },
        
            // 2 gün sonrası
            new Randevu { Id = 12, CalisanId = 2, IslemId = 7, Tarih = DateTime.UtcNow.AddDays(2).Date.AddHours(9), KullaniciId = 4, Kazanc = 150, IslemSuresi = 40, Durum = "Beklemede" },
            new Randevu { Id = 13, CalisanId = 3, IslemId = 8, Tarih = DateTime.UtcNow.AddDays(2).Date.AddHours(12), KullaniciId = 5, Kazanc = 50, IslemSuresi = 20, Durum = "Onaylandı" },
            new Randevu { Id = 14, CalisanId = 4, IslemId = 9, Tarih = DateTime.UtcNow.AddDays(2).Date.AddHours(15), KullaniciId = 2, Kazanc = 250, IslemSuresi = 40, Durum = "Reddedildi" },
        
            // 3 gün sonrası
            new Randevu { Id = 15, CalisanId = 5, IslemId = 1, Tarih = DateTime.UtcNow.AddDays(3).Date.AddHours(10), KullaniciId = 3, Kazanc = 250, IslemSuresi = 40, Durum = "Onaylandı" },
            new Randevu { Id = 16, CalisanId = 1, IslemId = 2, Tarih = DateTime.UtcNow.AddDays(3).Date.AddHours(12), KullaniciId = 4, Kazanc = 1500, IslemSuresi = 175, Durum = "Beklemede" },
            new Randevu { Id = 17, CalisanId = 2, IslemId = 3, Tarih = DateTime.UtcNow.AddDays(3).Date.AddHours(16), KullaniciId = 5, Kazanc = 200, IslemSuresi = 20, Durum = "Onaylandı" },
        
            // 4 gün sonrası
            new Randevu { Id = 18, CalisanId = 3, IslemId = 4, Tarih = DateTime.UtcNow.AddDays(4).Date.AddHours(9), KullaniciId = 2, Kazanc = 820, IslemSuresi = 200, Durum = "Beklemede" },
            new Randevu { Id = 19, CalisanId = 4, IslemId = 5, Tarih = DateTime.UtcNow.AddDays(4).Date.AddHours(11), KullaniciId = 3, Kazanc = 1000, IslemSuresi = 180, Durum = "Reddedildi" },
            new Randevu { Id = 20, CalisanId = 5, IslemId = 6, Tarih = DateTime.UtcNow.AddDays(4).Date.AddHours(14), KullaniciId = 4, Kazanc = 150, IslemSuresi = 40, Durum = "Onaylandı" },
        
            // 5 gün sonrası
            new Randevu { Id = 21, CalisanId = 1, IslemId = 7, Tarih = DateTime.UtcNow.AddDays(5).Date.AddHours(10), KullaniciId = 5, Kazanc = 150, IslemSuresi = 40, Durum = "Beklemede" },
            new Randevu { Id = 22, CalisanId = 2, IslemId = 8, Tarih = DateTime.UtcNow.AddDays(5).Date.AddHours(13), KullaniciId = 2, Kazanc = 50, IslemSuresi = 20, Durum = "Onaylandı" },
            new Randevu { Id = 23, CalisanId = 3, IslemId = 9, Tarih = DateTime.UtcNow.AddDays(5).Date.AddHours(15), KullaniciId = 3, Kazanc = 250, IslemSuresi = 40, Durum = "Reddedildi" },
        
            // 6 gün sonrası
            new Randevu { Id = 24, CalisanId = 4, IslemId = 1, Tarih = DateTime.UtcNow.AddDays(6).Date.AddHours(9), KullaniciId = 4, Kazanc = 250, IslemSuresi = 40, Durum = "Onaylandı" },
            new Randevu { Id = 25, CalisanId = 5, IslemId = 2, Tarih = DateTime.UtcNow.AddDays(6).Date.AddHours(11), KullaniciId = 5, Kazanc = 1500, IslemSuresi = 175, Durum = "Beklemede" },
            new Randevu { Id = 26, CalisanId = 1, IslemId = 3, Tarih = DateTime.UtcNow.AddDays(6).Date.AddHours(14), KullaniciId = 2, Kazanc = 200, IslemSuresi = 20, Durum = "Onaylandı" },
        
            // 7 gün sonrası
            new Randevu { Id = 27, CalisanId = 2, IslemId = 4, Tarih = DateTime.UtcNow.AddDays(7).Date.AddHours(10), KullaniciId = 3, Kazanc = 820, IslemSuresi = 200, Durum = "Beklemede" },
            new Randevu { Id = 28, CalisanId = 3, IslemId = 5, Tarih = DateTime.UtcNow.AddDays(7).Date.AddHours(13), KullaniciId = 4, Kazanc = 1000, IslemSuresi = 180, Durum = "Reddedildi" },
            new Randevu { Id = 29, CalisanId = 4, IslemId = 6, Tarih = DateTime.UtcNow.AddDays(7).Date.AddHours(15), KullaniciId = 5, Kazanc = 150, IslemSuresi = 40, Durum = "Onaylandı" }
        );
        
        }

    }
}
