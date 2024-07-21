using System.ComponentModel.DataAnnotations;

namespace Library.Application.Models.Books.Request;

public class BookPostRequest
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter entre 3 e 50 caracteres.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "O campo Tipo de Usuário é obrigatório.")]
    public Guid GenderId { get; set; }

    [Required(ErrorMessage = "O campo Função é obrigatório.")]
    public Guid AuthorId { get; set; }
}
