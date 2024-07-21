using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace Library.Api.Middlewares
{
    /// <summary>
    /// Class that handles exceptions threw by application
    /// </summary>
    public static class GlobalExceptionHandler
    {
        /// <summary>
        /// Method that handle the exceptions caught by ExceptionHandlerMiddleware
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns>A response containing a json object with exception errors. Otherwise, null</returns>
        public static async Task Handle(HttpContext httpContext)
        {
            var exceptionHandlerFeature = httpContext.Features.Get<IExceptionHandlerFeature>();
            
            if (exceptionHandlerFeature is null) return;

            var (httpStatusCode, message) = exceptionHandlerFeature.Error switch
            {
                ArgumentException ex => (HttpStatusCode.BadRequest, ex.Message),
                _ => (HttpStatusCode.InternalServerError, "Erro inesperado")
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)httpStatusCode;

            var jsonResponse = new
            {
                httpContext.Response.StatusCode,
                Message = message,
                Errors = new List<string>(),
            };

            var jsonSerialised = JsonSerializer.Serialize(jsonResponse);
            await httpContext.Response.WriteAsync(jsonSerialised);
        }
    }
}
