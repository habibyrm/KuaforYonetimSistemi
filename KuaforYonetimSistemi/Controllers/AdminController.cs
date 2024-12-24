using KuaforYonetimSistemi.Models;
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
            // Tüm randevuları çek
            var randevular = _context.Randevu
                .Include(r => r.Kullanici)
                .Include(r => r.Calisan)
                .Include(r => r.Islem)
                .ToList();

            return View(randevular);
        }

        public IActionResult Rapor()
        {
            return View();
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
            var calisanVerimlilik = _context.Randevu
                .Include(r => r.Calisan)
                .Where(r => r.Tarih.Date == bugun && r.Durum == "Onaylandı")
                .GroupBy(r => r.Calisan.AdSoyad)
                .Select(g => new
                {
                    Calisan = g.Key,
                    ToplamSure = g.Sum(r => r.IslemSuresi),
                    ToplamKazanc = g.Sum(r => r.Kazanc)
                }).ToList();

            ViewBag.Bugun = bugun.ToString("dd.MM.yyyy");
            return View(calisanVerimlilik);
        }
    }
}
