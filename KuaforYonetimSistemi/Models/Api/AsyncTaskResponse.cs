namespace KuaforYonetimSistemi.Models.Api
{
    public class AsyncTaskResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public int TaskStatus { get; set; }
        public ApiData Data { get; set; }
    }

}
