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
                new Islem { Id = 1, Ad = "Saç Kesimi", Ucret = 50 },
                new Islem { Id = 2, Ad = "Saç Boyama", Ucret = 150 },
                new Islem { Id = 3, Ad = "Fön Çekme", Ucret = 30 },
                new Islem { Id = 4, Ad = "Saç Bakımı", Ucret = 120 },
                new Islem { Id = 5, Ad = "Perma", Ucret = 200 },
                new Islem { Id = 6, Ad = "Manikür", Ucret = 80 },
                new Islem { Id = 7, Ad = "Pedikür", Ucret = 90 },
                new Islem { Id = 8, Ad = "Kaş Alma", Ucret = 40 },
                new Islem { Id = 9, Ad = "Makyaj", Ucret = 250 }
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

            // Randevular
            modelBuilder.Entity<Randevu>().HasData(
                new Randevu { Id = 1, CalisanId = 1, IslemId = 1, Tarih = DateTime.UtcNow.AddDays(1), KullaniciId = 2, Kazanc = 50, IslemSuresi = 30, Durum = "Onaylandı" },
                new Randevu { Id = 2, CalisanId = 2, IslemId = 4, Tarih = DateTime.UtcNow.AddDays(2), KullaniciId = 3, Kazanc = 120, IslemSuresi = 60, Durum = "Beklemede" },
                new Randevu { Id = 3, CalisanId = 3, IslemId = 5, Tarih = DateTime.UtcNow.AddDays(3), KullaniciId = 4, Kazanc = 200, IslemSuresi = 90, Durum = "Reddedildi" },
                new Randevu { Id = 4, CalisanId = 4, IslemId = 9, Tarih = DateTime.UtcNow.AddDays(4), KullaniciId = 5, Kazanc = 250, IslemSuresi = 120, Durum = "Beklemede" }
            );
        }
    }
}