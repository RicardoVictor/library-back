using Library.Api.Controllers.Base;
using Library.Application.Interfaces.Services.Genders;
using Library.Application.Models.Books.Request;
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
            
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
            => Result(await _service.GetByIdAsync(id));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] GenderPostRequest model)
            => Result(await _service.PostAsync(model));

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] GenderUpdateRequest book)
            => Result(await _service.UpdateAsync(id, book));
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
            => Result(await _service.DeleteAsync(id));
    }
}
