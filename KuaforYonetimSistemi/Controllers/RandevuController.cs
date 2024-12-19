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
            var kullaniciId = HttpContext.Session.GetString("KullaniciId");
            if (string.IsNullOrEmpty(kullaniciId))
            {
                return RedirectToAction("GirisYap", "Kullanici");
            }
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
                TempData["Error"] = "Geçersiz çalışan veya işlem seçimi.";
                return RedirectToAction("Index");
            }

            ViewBag.Calisan = calisan;
            ViewBag.Islem = islem;

            return View();
        }

        [HttpGet]
        public IActionResult Tamamla(int calisanId, int islemId)
        {
            ViewBag.Calisan = _context.Calisan.Find(calisanId);
            ViewBag.Islem = _context.Islem.Find(islemId);

            return View();
        }

        [HttpPost]
        public IActionResult Tamamla(int calisanId, int islemId, DateTime tarih)
        {
            if (tarih <= DateTime.Now)
            {
                TempData["Error"] = "Geçmiş bir tarihle randevu oluşturulamaz.";
                return RedirectToAction("Index");
            }

            var islem = _context.Islem.FirstOrDefault(i => i.Id == islemId);
            if (islem == null)
            {
                TempData["Error"] = "Seçilen işlem bulunamadı.";
                return RedirectToAction("Index");
            }

            // İşlem süresi
            var islemSuresi = islem.Sure;

            // Randevu çakışması kontrolü
            var randevuBitisSaati = tarih.AddMinutes(islemSuresi);

            var calisanRandevular = _context.Randevu
                .Where(r => r.CalisanId == calisanId && r.Durum == "Onaylandı")
                .ToList();

            foreach (var r in calisanRandevular)
            {
                var mevcutRandevuBaslangic = r.Tarih;
                var mevcutRandevuBitis = r.Tarih.AddMinutes(r.IslemSuresi);

                // Çakışma kontrolü
                if ((tarih >= mevcutRandevuBaslangic && tarih < mevcutRandevuBitis) ||
                    (randevuBitisSaati > mevcutRandevuBaslangic && randevuBitisSaati <= mevcutRandevuBitis))
                {
                    TempData["Error"] = "Bu saat aralığında bu çalışandan randevu alınamaz.";
                    return RedirectToAction("Index");
                }
            }

            // Yeni randevuyu kaydet
            var yeniRandevu = new Randevu
            {
                CalisanId = calisanId,
                IslemId = islemId,
                Tarih = tarih,
                KullaniciId = int.Parse(HttpContext.Session.GetString("KullaniciId")),
                Kazanc = islem.Ucret,
                IslemSuresi = islemSuresi,
                Durum = "Beklemede" // Yeni randevu durumu beklemede olarak ayarlanır
            };

            _context.Randevu.Add(yeniRandevu);
            _context.SaveChanges();

            TempData["Success"] = "Randevunuz başarıyla oluşturuldu.";
            return RedirectToAction("Index");
        }

    }
}