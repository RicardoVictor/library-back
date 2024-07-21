using Library.Domain.Entities;
using Library.Domain.Model;
using System.Linq.Expressions;

namespace Library.Domain.Helper
{
    public static class BookFilterHelper
    {
        public static Expression<Func<Book, bool>> ApplyFilters(BookFilterModel model) => book =>
            (string.IsNullOrWhiteSpace(model.Name) || book.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower())) &&
            (!model.Authors.Any() || model.Authors.Contains(book.Author.Name)) &&
            (!model.Genders.Any() || model.Genders.Contains(book.Gender.Name));
    }
}
