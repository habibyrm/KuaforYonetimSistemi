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
        _httpClient.DefaultRequestHeaders.Add("****", "***"); // API anahtarınızı buraya ekleyin.
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
        string apiUrl = "****";

        // İlk istek: task_id almak için
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
        Console.WriteLine($"API Yanıtı (İlk İstek): {responseData}");

        var result = JsonConvert.DeserializeObject<ApiResponse>(responseData);

        if (result == null || string.IsNullOrEmpty(result.TaskId))
        {
            throw new Exception("API, geçerli bir task_id döndürmedi.");
        }

        // İkinci istek: İşlenmiş resmi almak için
        string queryUrl = $"https://www.ailabapi.com/api/common/query-async-task-result?task_id={result.TaskId}";

        string processedImageUrl = await GetProcessedImageUrlAsync(queryUrl);
        return processedImageUrl;
    }

    private async Task<string> GetProcessedImageUrlAsync(string queryUrl)
    {
        // İşlenmiş sonucu sorgulama
        for (int i = 0; i < 10; i++) // 10 kez dene (timeout)
        {
            await Task.Delay(2000); // 2 saniye bekle
            var response = await _httpClient.GetAsync(queryUrl);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"API Yanıtı (Sonuç Sorgusu): {responseData}");

            var result = JsonConvert.DeserializeObject<AsyncTaskResponse>(responseData);

            if (result != null && result.Data != null && !string.IsNullOrEmpty(result.Data.ImageUrl))
            {
                return result.Data.ImageUrl;
            }
        }

        throw new Exception("API, işlenmiş resim URL'sini zamanında döndürmedi.");
    }
}
