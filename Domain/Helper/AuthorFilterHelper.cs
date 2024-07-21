using Library.Domain.Entities;
using Library.Domain.Model;
using System.Linq.Expressions;

namespace Library.Domain.Helper
{
    public static class AuthorFilterHelper
    {
        public static Expression<Func<Author, bool>> ApplyFilters(AuthorFilterModel model) => author =>
            string.IsNullOrWhiteSpace(model.Name) || author.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower());
    }
}
