using KuaforYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KuaforYonetimSistemi.Controllers
{
    public class RaporController : Controller
    {
        public async Task<IActionResult> GunlukRapor(string tarih)
        {
            if (string.IsNullOrEmpty(tarih))
            {
                // Tarih seçilmemişse boş bir liste gönder
                ViewBag.Error = "Lütfen bir tarih seçin.";
                return View(new List<RaporViewModel>());
            }

            List<RaporViewModel> raporlar = new List<RaporViewModel>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = $"https://localhost:7030/api/RaporApi/gunluk-rapor?tarih={tarih}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonData = await response.Content.ReadAsStringAsync();
                        raporlar = JsonConvert.DeserializeObject<List<RaporViewModel>>(jsonData);
                    }
                    else
                    {
                        ViewBag.Error = "Rapor verileri alınırken bir hata oluştu.";
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Error = $"API ile bağlantı kurulamadı: {ex.Message}";
                }
            }

            return View(raporlar);
        }
    }
}