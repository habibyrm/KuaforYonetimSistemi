using Newtonsoft.Json;

public class AsyncTaskResponse
{
    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
    public int TaskStatus { get; set; } // 2 = Success
    public ApiData Data { get; set; }
}

public class ApiData
{
    [JsonProperty("image_url")]
    public string ImageUrl { get; set; }
}
