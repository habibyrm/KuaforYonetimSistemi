using KuaforYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KuaforYonetimSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RandevuAl()
        {
            // Kullan�c� oturum a�m�� m� kontrol et
            if (HttpContext.Session.GetString("KullaniciId") == null)
            {
                // Oturum a�mam��sa Giri� Yap ekran�na y�nlendir
                return RedirectToAction("GirisYap", "Kullanici");
            }

            // Oturum a�m��sa Randevu ekran�na y�nlendir
            return RedirectToAction("Index", "Randevu");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
