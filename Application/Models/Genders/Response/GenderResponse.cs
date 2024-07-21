using Library.Domain.Entities;

namespace Library.Application.Models.Genders.Response
{
    public class GenderResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public static implicit operator GenderResponse(Gender entity) => new()
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}
