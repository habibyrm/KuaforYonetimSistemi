using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Text;
using System.Text.Json;

namespace KuaforYonetimSistemi.Controllers
{
    public class AIController : Controller
    {
        private readonly string apiUrl = "https://api-inference.huggingface.co/models/stabilityai/stable-diffusion-xl-refiner-1.0";
        private readonly string apiKey = "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";

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile uploadedImage)
        {
            if (uploadedImage == null || uploadedImage.Length == 0)
            {
                ViewBag.Error = "Lütfen bir fotoğraf yükleyin.";
                return View();
            }

            // Görseli kontrol et ve gerekirse yeniden boyutlandır
            using var resizedStream = await ValidateAndResizeImage(uploadedImage);
            if (resizedStream == null)
            {
                ViewBag.Error = "Görsel boyutu çok küçük. En az 256x256 piksel boyutunda bir görsel yükleyin.";
                return View();
            }

            // Görseli Base64 formatına çevir
            string base64Image = ConvertStreamToBase64(resizedStream);

            // API isteği için JSON verisi hazırla
            var requestData = new
            {
                inputs = base64Image,
                parameters = new
                {
                    candidate_labels = new[] { "short hair", "long hair", "curly hair" }
                }
            };
            var jsonData = JsonSerializer.Serialize(requestData);

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiUrl, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Result = responseContent;
            }
            else
            {
                ViewBag.Error = $"API Hatası: {responseContent}";
            }

            return View();
        }

        private async Task<Stream> ValidateAndResizeImage(IFormFile uploadedImage)
        {
            using var originalStream = uploadedImage.OpenReadStream();
            var originalImage = Image.FromStream(originalStream);

            if (originalImage.Width < 256 || originalImage.Height < 256)
            {
                // Görseli yeniden boyutlandır
                var resizedImage = new Bitmap(256, 256);
                using (var graphics = Graphics.FromImage(resizedImage))
                {
                    graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    graphics.DrawImage(originalImage, 0, 0, 256, 256);
                }

                var memoryStream = new MemoryStream();
                resizedImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                memoryStream.Position = 0; // Stream'in başlangıcına dön
                return memoryStream;
            }

            return originalStream; // Eğer boyut uygunsa orijinal görseli döndür
        }

        private string ConvertStreamToBase64(Stream imageStream)
        {
            using var memoryStream = new MemoryStream();
            imageStream.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();
            return Convert.ToBase64String(imageBytes);
        }
    }
}
