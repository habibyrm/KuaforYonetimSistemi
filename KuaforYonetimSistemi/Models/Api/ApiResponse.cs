using Newtonsoft.Json;

namespace KuaforYonetimSistemi.Models.Api
{
    public class ApiResponse
    {
        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("error_detail")]
        public ErrorDetail ErrorDetail { get; set; }

        [JsonProperty("log_id")]
        public string LogId { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        [JsonProperty("task_type")]
        public string TaskType { get; set; }
    }

    public class ErrorDetail
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("code_message")]
        public string CodeMessage { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
