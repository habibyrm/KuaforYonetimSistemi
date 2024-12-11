using KuaforYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KuaforYonetimSistemi.Controllers
{
    public class IslemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IslemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? calisanId, int? islemId)
        {
            // Tüm çalışan-işlem ilişkilerini getiriyoruz
            var calisanIslemler = _context.CalisanIslem.AsQueryable();

            // Çalışan filtreleme
            if (calisanId.HasValue)
            {
                calisanIslemler = calisanIslemler.Where(ci => ci.CalisanId == calisanId.Value);
            }

            // İşlem filtreleme
            if (islemId.HasValue)
            {
                calisanIslemler = calisanIslemler.Where(ci => ci.IslemId == islemId.Value);
            }

            // İlişkili işlemleri çekiyoruz
            var islemler = calisanIslemler
                .Select(ci => ci.Islem)
                .Distinct()
                .ToList();

            // ViewData ile çalışan ve işlem listelerini taşıyoruz
            ViewData["Calisanlar"] = _context.Calisan.ToList();
            ViewData["Islemler"] = _context.Islem.ToList();
            ViewData["selectedCalisanId"] = calisanId;
            ViewData["selectedIslemId"] = islemId;

            return View(islemler);
        }
    }
}
