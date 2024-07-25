using Library.Api.Controllers.Base;
using Library.Application.Interfaces.Services.Genders;
using Library.Application.Models.Books.Request;
using Library.Application.Models.Genders.Request;
using Library.Application.Models.Genders.Response;
using Library.Domain.Common;
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

        /// <summary>
        /// Obtém uma lista de gêneros paginada e filtrada.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedList<GenderResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromQuery] GenderFilterRequest model)
            => Result(await _service.GetAsync(model));

        /// <summary>
        /// Obtém um gênero específico pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenderResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
            => Result(await _service.GetByIdAsync(id));

        /// <summary>
        /// Adiciona um novo gênero.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] GenderPostRequest model)
            => Result(await _service.PostAsync(model));

        /// <summary>
        /// Atualiza um gênero existente.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] GenderUpdateRequest book)
            => Result(await _service.UpdateAsync(id, book));
        
        /// <summary>
        /// Remove um gênero pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
            => Result(await _service.DeleteAsync(id));
    }
}
