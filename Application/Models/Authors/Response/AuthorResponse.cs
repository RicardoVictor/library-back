using Library.Domain.Entities;

namespace Library.Application.Models.Authors.Response
{
    public class AuthorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public static implicit operator AuthorResponse(Author entity) => new()
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}
