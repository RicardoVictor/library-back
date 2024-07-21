using Library.Api.Controllers.Base;
using Library.Application.Interfaces.Services.Authors;
using Library.Application.Models.Authors.Request;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromQuery] AuthorFilterRequest model)
            => Result(await _service.GetAsync(model));
    }
}
