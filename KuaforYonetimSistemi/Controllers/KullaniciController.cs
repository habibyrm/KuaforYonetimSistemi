﻿using KuaforYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KuaforYonetimSistemi.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KullaniciController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Kayıt ol sayfası
        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KayitOl(Kullanici musteri)
        {
            if (ModelState.IsValid)
            {
                // E-posta kontrolü (aynı e-posta ile kayıt engellenir)
                if (_context.Kullanici.Any(m => m.Email == musteri.Email))
                {
                    ViewBag.Hata = "Bu e-posta adresi zaten kayıtlı.";
                    return View(musteri);
                }

                musteri.Sifre = SifreOlustur(musteri.Sifre); // Şifreyi hashle
                _context.Kullanici.Add(musteri);
                _context.SaveChanges();

                ViewBag.Basari = "Kayıt işlemi başarılı!";
                return View();
            }

            ViewBag.Hata = "Geçersiz giriş bilgileri, lütfen tekrar deneyin.";
            return View(musteri);
        }

        // Giriş yap sayfası
        public IActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GirisYap(string email, string sifre)
        {
            var kullanici = _context.Kullanici.FirstOrDefault(k => k.Email == email);
            if (kullanici != null && SifreDogrula(sifre, kullanici.Sifre))
            {
                HttpContext.Session.SetString("KullaniciId", kullanici.Id.ToString());
                HttpContext.Session.SetString("AdminMi", (kullanici.Rol == "Admin").ToString());

                // Giriş başarılıysa HomeController'daki Index metoduna yönlendir
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Hata = "Hatalı giriş! Lütfen bilgilerinizi kontrol edin.";
            return View();
        }

        public IActionResult CikisYap()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("GirisYap");
        }

        private static string SifreOlustur(string sifre)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] sifreBytes = System.Text.Encoding.UTF8.GetBytes(sifre);
                byte[] hashBytes = sha256.ComputeHash(sifreBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private bool SifreDogrula(string girilenSifre, string hashlenmisSifre)
        {
            string girilenHash = SifreOlustur(girilenSifre);
            return girilenHash == hashlenmisSifre;
        }
    }
}