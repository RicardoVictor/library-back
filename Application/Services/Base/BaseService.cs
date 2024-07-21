using System.Net;
using Library.Application.Models.Base;

namespace Library.Application.Services.Base
{
    public abstract class BaseService
    {
        public static BaseResponse<T> SetErrorResponse<T>(HttpStatusCode statusCode, string message, List<string> errors)
        {
            return new()
            {
               Success = false,
               StatusCode = statusCode,
               Message = message,
               Errors = errors
            };
        }

        public static BaseResponse<T> SetErrorResponse<T>(HttpStatusCode statusCode, string message)
        {
            return new()
            {
                Success = false,
                StatusCode = statusCode,
                Message = message,
            };
        }

        public static BaseResponse<T> SetSuccessResponse<T>(HttpStatusCode statusCode, T data)
        {
            return new()
            {
                Success = true,
                StatusCode = statusCode,
                Data = data,
                Message = string.Empty
            };
        }
    }
}
