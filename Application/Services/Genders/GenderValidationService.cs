using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;

namespace Library.Application.Interfaces.Services.Genders;

public class GenderValidationService : IGenderValidationService
{
    private readonly IGenderRepository _repository;

    public GenderValidationService(IGenderRepository repository)
    {
        _repository = repository;
    }

    public async Task<(Gender?, string)> ValidateExistsAsync(Guid id)
    {
        var gender = await _repository.GetOneAsync(u => u.Id == id);

        if (gender is null) return (gender, "Tipo não encontrado.");

        return (gender, string.Empty);
    }
}
