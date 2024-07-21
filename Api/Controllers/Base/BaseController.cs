using System.Net;
using Library.Application.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {

        public IActionResult Result<T>(BaseResponse<T> response) 
        {
            if (response == null)
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = "Erro inesperado" });

            if (!response.Success)
                return Error(response);                

            return Success(response);
        }

        private IActionResult Success<T>(BaseResponse<T> response)
        {
            switch(response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return Ok(response.Data);
                case HttpStatusCode.Created:
                    return Created(HttpContext.Request.Path, response.Data);
                case HttpStatusCode.NoContent:
                    return NoContent();
                default:
                    return StatusCode((int)response.StatusCode);
            }
        }

        private IActionResult Error<T>(BaseResponse<T> response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest(new { response.Message, response.Errors });
                case HttpStatusCode.Unauthorized:
                    return Unauthorized(new { response.Message });
                case HttpStatusCode.Forbidden:
                    return StatusCode((int)HttpStatusCode.Forbidden, new { response.Message });
                default:
                    return StatusCode((int)response.StatusCode);
            }
        }
    }
}
