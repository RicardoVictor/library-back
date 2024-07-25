using Library.Api.Controllers.Base;
using Library.Application.Interfaces.Services.Authors;
using Library.Application.Models.Authors.Request;
using Library.Application.Models.Authors.Response;
using Library.Application.Models.Books.Request;
using Library.Domain.Common;
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

        /// <summary>
        /// Obtém uma lista de autores paginada e filtrada.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedList<AuthorResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromQuery] AuthorFilterRequest model)
            => Result(await _service.GetAsync(model));

        /// <summary>
        /// Obtém um autor específico pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
            => Result(await _service.GetByIdAsync(id));

        /// <summary>
        /// Adiciona um novo autor.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] AuthorPostRequest model)
            => Result(await _service.PostAsync(model));

        /// <summary>
        /// Atualiza um autor existente.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] AuthorUpdateRequest book)
            => Result(await _service.UpdateAsync(id, book));

        /// <summary>
        /// Remove um autor pelo ID.
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
