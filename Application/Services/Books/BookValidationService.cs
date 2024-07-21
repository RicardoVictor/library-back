using Library.Application.Interfaces.Services.Books;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;

namespace Library.Application.Services.Books;

public class BookValidationService : IBookValidationService
{
    private readonly IBookRepository _repository;

    public BookValidationService(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<(Book?, string)> ValidateExistsAsync(Guid id)
    {
        var book = await _repository.GetOneAsync(u => u.Id == id);

        if (book is null) return (book, "Usuário não encontrado.");

        return (book, string.Empty);
    }
}
