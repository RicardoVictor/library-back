using Library.Api.Controllers.Base;
using Library.Application.Interfaces.Services.Genders;
using Library.Application.Models.Genders.Request;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    public class GenderController : BaseController
    {
        private readonly IGenderService _service;

        public GenderController(IGenderService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromQuery] GenderFilterRequest model)
            => Result(await _service.GetAsync(model));
    }
}
