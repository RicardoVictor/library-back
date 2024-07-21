using Library.Application.Models.Authors.Response;
using Library.Application.Models.Genders.Response;
using Library.Domain.Entities;

namespace Library.Application.Models.Books.Response
{
    public class BookResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public AuthorResponse? Author { get; set; }
        public GenderResponse? Gender { get; set; }

        public static implicit operator BookResponse(Book entity) => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Author = entity.Author,
            Gender = entity.Gender,
        };
    }
}
