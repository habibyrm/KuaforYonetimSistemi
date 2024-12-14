﻿using KuaforYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KuaforYonetimSistemi.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Admin paneline erişim yetkisi kontrolü
        private bool AdminYetkisi()
        {
            var rol = HttpContext.Session.GetString("Rol");
            return rol == "Admin";
        }

        // Admin Paneli Ana Sayfası
        public IActionResult Index()
        {
            if (!AdminYetkisi())
            {
                return RedirectToAction("GirisYap", "Kullanici");
            }

            var bekleyenRandevular = _context.Randevu
                .Include(r => r.Calisan)
                .Include(r => r.Islem)
                .Include(r => r.Kullanici)
                .Where(r => r.Durum == "Beklemede")
                .ToList();

            return View(bekleyenRandevular);
        }

        [HttpPost]
        public IActionResult Onayla(int id)
        {
            if (!AdminYetkisi())
            {
                return RedirectToAction("GirisYap", "Kullanici");
            }

            var randevu = _context.Randevu.Find(id);
            if (randevu != null)
            {
                randevu.Durum = "Onaylandı";
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Reddet(int id)
        {
            if (!AdminYetkisi())
            {
                return RedirectToAction("GirisYap", "Kullanici");
            }

            var randevu = _context.Randevu.Find(id);
            if (randevu != null)
            {
                randevu.Durum = "Reddedildi";
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Raporlar()
        {
            if (!AdminYetkisi())
            {
                return RedirectToAction("GirisYap", "Kullanici");
            }

            var bugun = DateTime.Today;
            var birHaftaOnce = bugun.AddDays(-7);

            var verimlilik = _context.Randevu
                .Include(r => r.Calisan)
                .Where(r => r.Durum == "Onaylandı" && r.Tarih >= birHaftaOnce && r.Tarih <= bugun)
                .GroupBy(r => r.Calisan.AdSoyad)
                .Select(g => new
                {
                    Calisan = g.Key,
                    TamamlananRandevuSayisi = g.Count(),
                    ToplamKazanc = g.Sum(r => r.Kazanc)
                }).ToList();

            var gunlukKazanc = _context.Randevu
                .Where(r => r.Durum == "Onaylandı" && r.Tarih.Date == bugun)
                .Sum(r => r.Kazanc);

            ViewBag.GunlukKazanc = gunlukKazanc;
            return View(verimlilik);
        }
    }
}
