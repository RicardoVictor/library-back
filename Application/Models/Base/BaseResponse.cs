using System.Net;

namespace Library.Application.Models.Base
{
    public class BaseResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<string> Errors { get; set; }
        public T? Data { get; set; }
    }
}
