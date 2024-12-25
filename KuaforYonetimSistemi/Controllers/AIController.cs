using System.Net.Http.Headers;
using KuaforYonetimSistemi.Models.Api;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class AIController : Controller
{
    private readonly HttpClient _httpClient;

    public AIController()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("ailabapi-api-key", "yZFRP8p1re69YDNOhSTKDUco7Suz3XybElm7snOk54WEXrtazbqljRHmteULdqC4"); // API anahtarınızı buraya ekleyin.
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile image, string hairStyle)
    {
        if (image == null || image.Length == 0)
        {
            ModelState.AddModelError("image", "Lütfen bir resim yükleyin.");
            return View("Index");
        }

        try
        {
            // Resmi API'ye gönder ve işlenmiş resmin URL'sini al
            var processedImageUrl = await ChangeHairstyleAsync(image, hairStyle);
            ViewBag.ProcessedImageUrl = processedImageUrl;
        }
        catch (HttpRequestException ex)
        {
            ViewBag.Error = $"API hatası: {ex.Message}";
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Bilinmeyen hata: {ex.Message}";
        }

        return View("Index");
    }

    private async Task<string> ChangeHairstyleAsync(IFormFile imageFile, string hairStyle)
    {
        string apiUrl = "https://www.ailabapi.com/api/portrait/effects/hairstyle-editor-pro";

        using var content = new MultipartFormDataContent();
        using var imageContent = new StreamContent(imageFile.OpenReadStream());
        imageContent.Headers.ContentType = new MediaTypeHeaderValue(imageFile.ContentType);
        content.Add(imageContent, "image", imageFile.FileName);
        content.Add(new StringContent("async"), "task_type");
        content.Add(new StringContent("1"), "auto");
        content.Add(new StringContent(hairStyle), "hair_style");

        var response = await _httpClient.PostAsync(apiUrl, content);
        response.EnsureSuccessStatusCode();

        var responseData = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"API Yanıtı: {responseData}");

        var result = JsonConvert.DeserializeObject<ApiResponse>(responseData);

        if (result == null)
        {
            throw new Exception("API'den beklenmeyen bir yanıt alındı.");
        }

        if (result.ErrorCode != 0)
        {
            throw new Exception($"API Hatası: {result.ErrorMessage}");
        }

        if (result.Data == null || string.IsNullOrEmpty(result.Data.ImageUrl))
        {
            throw new Exception("İşlenmiş resim URL'si alınamadı.");
        }

        return result.Data.ImageUrl;
    }
}
