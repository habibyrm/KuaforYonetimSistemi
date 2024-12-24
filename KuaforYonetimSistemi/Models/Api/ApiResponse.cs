namespace KuaforYonetimSistemi.Models.Api
{
    public class ApiResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public ApiData Data { get; set; }
    }
}
