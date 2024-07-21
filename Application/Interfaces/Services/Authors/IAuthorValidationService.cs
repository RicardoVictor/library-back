using Library.Domain.Entities;

namespace Library.Application.Interfaces.Services.Authors
{
    public interface IAuthorValidationService
    {
        Task<(Author?, string)> ValidateExistsAsync(Guid id);
    }
}
