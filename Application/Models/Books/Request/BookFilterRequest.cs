using Library.Domain.Model;

namespace Library.Application.Models.Books.Request
{
    public class BookFilterRequest
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Authors { get; set; } = new();
        public List<string> Genders { get; set; } = new();
        public int? PageNumber { get; set; } = null;
        public int? PageSize { get; set; } = null;

        public static implicit operator BookFilterModel(BookFilterRequest model) => new()
        {
            Name = model.Name,
            Authors = model.Authors,
            Genders = model.Genders,
            PageNumber = (int)(model.PageNumber == null ? 1 : model.PageNumber),
            PageSize = (int)(model.PageSize == null ? 10 : model.PageSize),
        };
    }
}
