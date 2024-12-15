﻿// <auto-generated />
using System;
using KuaforYonetimSistemi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KuaforYonetimSistemi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KuaforYonetimSistemi.Models.Calisan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UygunSaatler")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Calisan");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdSoyad = "Ayşe Yılmaz",
                            UygunSaatler = "09:00-18:00"
                        },
                        new
                        {
                            Id = 2,
                            AdSoyad = "Fatma Kaya",
                            UygunSaatler = "10:00-17:00"
                        },
                        new
                        {
                            Id = 3,
                            AdSoyad = "Elif Demir",
                            UygunSaatler = "08:00-16:00"
                        },
                        new
                        {
                            Id = 4,
                            AdSoyad = "Zehra Çelik",
                            UygunSaatler = "12:00-20:00"
                        },
                        new
                        {
                            Id = 5,
                            AdSoyad = "Gizem Arslan",
                            UygunSaatler = "11:00-19:00"
                        });
                });

            modelBuilder.Entity("KuaforYonetimSistemi.Models.CalisanIslem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CalisanId")
                        .HasColumnType("int");

                    b.Property<int>("IslemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CalisanId");

                    b.HasIndex("IslemId");

                    b.ToTable("CalisanIslem");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CalisanId = 1,
                            IslemId = 1
                        },
                        new
                        {
                            Id = 2,
                            CalisanId = 1,
                            IslemId = 3
                        },
                        new
                        {
                            Id = 3,
                            CalisanId = 1,
                            IslemId = 6
                        },
                        new
                        {
                            Id = 4,
                            CalisanId = 2,
                            IslemId = 2
                        },
                        new
                        {
                            Id = 5,
                            CalisanId = 2,
                            IslemId = 4
                        },
                        new
                        {
                            Id = 6,
                            CalisanId = 2,
                            IslemId = 7
                        },
                        new
                        {
                            Id = 7,
                            CalisanId = 3,
                            IslemId = 1
                        },
                        new
                        {
                            Id = 8,
                            CalisanId = 3,
                            IslemId = 5
                        },
                        new
                        {
                            Id = 9,
                            CalisanId = 3,
                            IslemId = 8
                        },
                        new
                        {
                            Id = 10,
                            CalisanId = 4,
                            IslemId = 3
                        },
                        new
                        {
                            Id = 11,
                            CalisanId = 4,
                            IslemId = 9
                        },
                        new
                        {
                            Id = 12,
                            CalisanId = 5,
                            IslemId = 2
                        },
                        new
                        {
                            Id = 13,
                            CalisanId = 5,
                            IslemId = 4
                        },
                        new
                        {
                            Id = 14,
                            CalisanId = 5,
                            IslemId = 8
                        });
                });

            modelBuilder.Entity("KuaforYonetimSistemi.Models.Islem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sure")
                        .HasColumnType("int");

                    b.Property<decimal>("Ucret")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Islem");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ad = "Saç Kesimi",
                            Sure = 40,
                            Ucret = 250m
                        },
                        new
                        {
                            Id = 2,
                            Ad = "Saç Boyama",
                            Sure = 175,
                            Ucret = 1500m
                        },
                        new
                        {
                            Id = 3,
                            Ad = "Fön Çekme",
                            Sure = 20,
                            Ucret = 200m
                        },
                        new
                        {
                            Id = 4,
                            Ad = "Saç Bakımı",
                            Sure = 200,
                            Ucret = 820m
                        },
                        new
                        {
                            Id = 5,
                            Ad = "Perma",
                            Sure = 180,
                            Ucret = 1000m
                        },
                        new
                        {
                            Id = 6,
                            Ad = "Manikür",
                            Sure = 40,
                            Ucret = 150m
                        },
                        new
                        {
                            Id = 7,
                            Ad = "Pedikür",
                            Sure = 40,
                            Ucret = 150m
                        },
                        new
                        {
                            Id = 8,
                            Ad = "Kaş Alma",
                            Sure = 20,
                            Ucret = 50m
                        },
                        new
                        {
                            Id = 9,
                            Ad = "Makyaj",
                            Sure = 40,
                            Ucret = 250m
                        });
                });

            modelBuilder.Entity("KuaforYonetimSistemi.Models.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kullanici");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@example.com",
                            KullaniciAdi = "admin",
                            Rol = "Admin",
                            Sifre = "12345"
                        },
                        new
                        {
                            Id = 2,
                            Email = "fatma@example.com",
                            KullaniciAdi = "fatma",
                            Rol = "Kullanici",
                            Sifre = "12345"
                        },
                        new
                        {
                            Id = 3,
                            Email = "ahmet@example.com",
                            KullaniciAdi = "ahmet",
                            Rol = "Kullanici",
                            Sifre = "12345"
                        },
                        new
                        {
                            Id = 4,
                            Email = "elif@example.com",
                            KullaniciAdi = "elif",
                            Rol = "Kullanici",
                            Sifre = "12345"
                        },
                        new
                        {
                            Id = 5,
                            Email = "gizem@example.com",
                            KullaniciAdi = "gizem",
                            Rol = "Kullanici",
                            Sifre = "12345"
                        });
                });

            modelBuilder.Entity("KuaforYonetimSistemi.Models.Randevu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CalisanId")
                        .HasColumnType("int");

                    b.Property<string>("Durum")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("Beklemede");

                    b.Property<int>("IslemId")
                        .HasColumnType("int");

                    b.Property<int>("IslemSuresi")
                        .HasColumnType("int");

                    b.Property<decimal>("Kazanc")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CalisanId");

                    b.HasIndex("IslemId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Randevu");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            CalisanId = 1,
                            Durum = "Onaylandı",
                            IslemId = 1,
                            IslemSuresi = 40,
                            Kazanc = 250m,
                            KullaniciId = 2,
                            Tarih = new DateTime(2024, 12, 14, 9, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 7,
                            CalisanId = 2,
                            Durum = "Beklemede",
                            IslemId = 2,
                            IslemSuresi = 175,
                            Kazanc = 1500m,
                            KullaniciId = 3,
                            Tarih = new DateTime(2024, 12, 14, 11, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 8,
                            CalisanId = 3,
                            Durum = "Onaylandı",
                            IslemId = 3,
                            IslemSuresi = 20,
                            Kazanc = 200m,
                            KullaniciId = 4,
                            Tarih = new DateTime(2024, 12, 14, 14, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 9,
                            CalisanId = 4,
                            Durum = "Beklemede",
                            IslemId = 4,
                            IslemSuresi = 200,
                            Kazanc = 820m,
                            KullaniciId = 5,
                            Tarih = new DateTime(2024, 12, 15, 10, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 10,
                            CalisanId = 5,
                            Durum = "Reddedildi",
                            IslemId = 5,
                            IslemSuresi = 180,
                            Kazanc = 1000m,
                            KullaniciId = 2,
                            Tarih = new DateTime(2024, 12, 15, 13, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 11,
                            CalisanId = 1,
                            Durum = "Onaylandı",
                            IslemId = 6,
                            IslemSuresi = 40,
                            Kazanc = 150m,
                            KullaniciId = 3,
                            Tarih = new DateTime(2024, 12, 15, 15, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 12,
                            CalisanId = 2,
                            Durum = "Beklemede",
                            IslemId = 7,
                            IslemSuresi = 40,
                            Kazanc = 150m,
                            KullaniciId = 4,
                            Tarih = new DateTime(2024, 12, 16, 9, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 13,
                            CalisanId = 3,
                            Durum = "Onaylandı",
                            IslemId = 8,
                            IslemSuresi = 20,
                            Kazanc = 50m,
                            KullaniciId = 5,
                            Tarih = new DateTime(2024, 12, 16, 12, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 14,
                            CalisanId = 4,
                            Durum = "Reddedildi",
                            IslemId = 9,
                            IslemSuresi = 40,
                            Kazanc = 250m,
                            KullaniciId = 2,
                            Tarih = new DateTime(2024, 12, 16, 15, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 15,
                            CalisanId = 5,
                            Durum = "Onaylandı",
                            IslemId = 1,
                            IslemSuresi = 40,
                            Kazanc = 250m,
                            KullaniciId = 3,
                            Tarih = new DateTime(2024, 12, 17, 10, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 16,
                            CalisanId = 1,
                            Durum = "Beklemede",
                            IslemId = 2,
                            IslemSuresi = 175,
                            Kazanc = 1500m,
                            KullaniciId = 4,
                            Tarih = new DateTime(2024, 12, 17, 12, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 17,
                            CalisanId = 2,
                            Durum = "Onaylandı",
                            IslemId = 3,
                            IslemSuresi = 20,
                            Kazanc = 200m,
                            KullaniciId = 5,
                            Tarih = new DateTime(2024, 12, 17, 16, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 18,
                            CalisanId = 3,
                            Durum = "Beklemede",
                            IslemId = 4,
                            IslemSuresi = 200,
                            Kazanc = 820m,
                            KullaniciId = 2,
                            Tarih = new DateTime(2024, 12, 18, 9, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 19,
                            CalisanId = 4,
                            Durum = "Reddedildi",
                            IslemId = 5,
                            IslemSuresi = 180,
                            Kazanc = 1000m,
                            KullaniciId = 3,
                            Tarih = new DateTime(2024, 12, 18, 11, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 20,
                            CalisanId = 5,
                            Durum = "Onaylandı",
                            IslemId = 6,
                            IslemSuresi = 40,
                            Kazanc = 150m,
                            KullaniciId = 4,
                            Tarih = new DateTime(2024, 12, 18, 14, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 21,
                            CalisanId = 1,
                            Durum = "Beklemede",
                            IslemId = 7,
                            IslemSuresi = 40,
                            Kazanc = 150m,
                            KullaniciId = 5,
                            Tarih = new DateTime(2024, 12, 19, 10, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 22,
                            CalisanId = 2,
                            Durum = "Onaylandı",
                            IslemId = 8,
                            IslemSuresi = 20,
                            Kazanc = 50m,
                            KullaniciId = 2,
                            Tarih = new DateTime(2024, 12, 19, 13, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 23,
                            CalisanId = 3,
                            Durum = "Reddedildi",
                            IslemId = 9,
                            IslemSuresi = 40,
                            Kazanc = 250m,
                            KullaniciId = 3,
                            Tarih = new DateTime(2024, 12, 19, 15, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 24,
                            CalisanId = 4,
                            Durum = "Onaylandı",
                            IslemId = 1,
                            IslemSuresi = 40,
                            Kazanc = 250m,
                            KullaniciId = 4,
                            Tarih = new DateTime(2024, 12, 20, 9, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 25,
                            CalisanId = 5,
                            Durum = "Beklemede",
                            IslemId = 2,
                            IslemSuresi = 175,
                            Kazanc = 1500m,
                            KullaniciId = 5,
                            Tarih = new DateTime(2024, 12, 20, 11, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 26,
                            CalisanId = 1,
                            Durum = "Onaylandı",
                            IslemId = 3,
                            IslemSuresi = 20,
                            Kazanc = 200m,
                            KullaniciId = 2,
                            Tarih = new DateTime(2024, 12, 20, 14, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 27,
                            CalisanId = 2,
                            Durum = "Beklemede",
                            IslemId = 4,
                            IslemSuresi = 200,
                            Kazanc = 820m,
                            KullaniciId = 3,
                            Tarih = new DateTime(2024, 12, 21, 10, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 28,
                            CalisanId = 3,
                            Durum = "Reddedildi",
                            IslemId = 5,
                            IslemSuresi = 180,
                            Kazanc = 1000m,
                            KullaniciId = 4,
                            Tarih = new DateTime(2024, 12, 21, 13, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 29,
                            CalisanId = 4,
                            Durum = "Onaylandı",
                            IslemId = 6,
                            IslemSuresi = 40,
                            Kazanc = 150m,
                            KullaniciId = 5,
                            Tarih = new DateTime(2024, 12, 21, 15, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("KuaforYonetimSistemi.Models.CalisanIslem", b =>
                {
                    b.HasOne("KuaforYonetimSistemi.Models.Calisan", "Calisan")
                        .WithMany("CalisanIslemler")
                        .HasForeignKey("CalisanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KuaforYonetimSistemi.Models.Islem", "Islem")
                        .WithMany("CalisanIslemler")
                        .HasForeignKey("IslemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calisan");

                    b.Navigation("Islem");
                });

            modelBuilder.Entity("KuaforYonetimSistemi.Models.Randevu", b =>
                {
                    b.HasOne("KuaforYonetimSistemi.Models.Calisan", "Calisan")
                        .WithMany()
                        .HasForeignKey("CalisanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KuaforYonetimSistemi.Models.Islem", "Islem")
                        .WithMany()
                        .HasForeignKey("IslemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KuaforYonetimSistemi.Models.Kullanici", "Kullanici")
                        .WithMany("Randevular")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calisan");

                    b.Navigation("Islem");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("KuaforYonetimSistemi.Models.Calisan", b =>
                {
                    b.Navigation("CalisanIslemler");
                });

            modelBuilder.Entity("KuaforYonetimSistemi.Models.Islem", b =>
                {
                    b.Navigation("CalisanIslemler");
                });

            modelBuilder.Entity("KuaforYonetimSistemi.Models.Kullanici", b =>
                {
                    b.Navigation("Randevular");
                });
#pragma warning restore 612, 618
        }
    }
}
