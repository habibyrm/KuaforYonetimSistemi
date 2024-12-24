using KuaforYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KuaforYonetimSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaporApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RaporApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<RandevuApiController>
        [HttpGet("gunluk-rapor")]
        public IActionResult GetGunlukRapor(DateTime tarih)
        {
            var rapor = _context.Randevu
                .Where(r => r.Tarih.Date == tarih.Date) // Verilen tarihteki randevuları filtrele
                .GroupBy(r => r.CalisanId) // Çalışanlara göre grupla
                .Select(g => new
                {
                    CalisanId = g.Key,
                    CalisanAdi = g.FirstOrDefault().Calisan.AdSoyad, // Çalışan adını al
                    ToplamSaat = g.Sum(r => r.IslemSuresi), // Dakika -> Saat
                    ToplamKazanc = g.Sum(r => r.Kazanc)
                })
                .ToList();

            return Ok(rapor);
        }
    }
}
