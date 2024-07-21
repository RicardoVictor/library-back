using Library.Domain.Entities;

namespace Library.Application.Interfaces.Services.Genders
{
    public interface IGenderValidationService
    {
        Task<(Gender?, string)> ValidateExistsAsync(Guid id);
    }
}
