using Library.Domain.Entities;

namespace Library.Application.Interfaces.Services.Books
{
    public interface IBookValidationService
    {
        Task<(Book?, string)> ValidateExistsAsync(Guid id);
    }
}
