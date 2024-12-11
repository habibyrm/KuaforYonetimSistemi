using KuaforYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KuaforYonetimSistemi.Controllers
{
    public class RandevuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RandevuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? calisanId, int? islemId)
        {
            ViewBag.SelectedCalisanId = calisanId;
            ViewBag.SelectedIslemId = islemId;

            ViewBag.Calisanlar = _context.Calisan.ToList();
            ViewBag.Islemler = _context.Islem.ToList();

            var calisanIslemler = _context.CalisanIslem
                .Include(ci => ci.Calisan)
                .Include(ci => ci.Islem)
                .AsQueryable();

            if (calisanId.HasValue)
                calisanIslemler = calisanIslemler.Where(ci => ci.CalisanId == calisanId.Value);

            if (islemId.HasValue)
                calisanIslemler = calisanIslemler.Where(ci => ci.IslemId == islemId.Value);

            return View(calisanIslemler.ToList());
        }



        public IActionResult Al(int calisanId, int islemId)
        {
            var calisan = _context.Calisan.FirstOrDefault(c => c.Id == calisanId);
            var islem = _context.Islem.FirstOrDefault(i => i.Id == islemId);

            if (calisan == null || islem == null)
            {
                return NotFound("Geçersiz çalışan veya işlem seçimi.");
            }

            ViewBag.Calisan = calisan;
            ViewBag.Islem = islem;

            return View();
        }

        [HttpPost]
        public IActionResult Tamamla(int calisanId, int islemId, DateTime tarih, int kullaniciId)
        {
            // Geçmiş tarih kontrolü
            if (tarih < DateTime.Now)
            {
                TempData["Error"] = "Geçmiş bir tarihle randevu oluşturulamaz.";
                return RedirectToAction("Index");
            }

            // Randevu çakışması kontrolü
            var mevcutRandevu = _context.Randevu
                .FirstOrDefault(r => r.CalisanId == calisanId && r.Tarih == tarih);

            if (mevcutRandevu != null)
            {
                TempData["Error"] = "Bu tarihte bu çalışandan randevu alınmış.";
                return RedirectToAction("Index");
            }

            // Yeni randevuyu kaydet
            var yeniRandevu = new Randevu
            {
                CalisanId = calisanId,
                IslemId = islemId,
                Tarih = tarih,
                KullaniciId = kullaniciId,
                Kazanc = _context.Islem.FirstOrDefault(i => i.Id == islemId)?.Ucret ?? 0,
                IslemSuresi = _context.Islem.FirstOrDefault(i => i.Id == islemId)?.Sure ?? 0
            };

            _context.Randevu.Add(yeniRandevu);
            _context.SaveChanges();

            TempData["Success"] = "Randevunuz başarıyla oluşturuldu.";
            return RedirectToAction("Index");
        }
    }
}
