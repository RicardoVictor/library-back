using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;

namespace Library.Application.Interfaces.Services.Authors;

public class AuthorValidationService : IAuthorValidationService
{
    private readonly IAuthorRepository _repository;

    public AuthorValidationService(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public async Task<(Author?, string)> ValidateExistsAsync(Guid id)
    {
        var author = await _repository.GetOneAsync(u => u.Id == id);

        if (author is null) return (author, "Author não encontrada.");

        return (author, string.Empty);
    }
}

