using Library.Domain.Entities;
using Library.Domain.Model;
using System.Linq.Expressions;

namespace Library.Domain.Helper
{
    public static class GenderFilterHelper
    {
        public static Expression<Func<Gender, bool>> ApplyFilters(GenderFilterModel model) => gender =>
            string.IsNullOrWhiteSpace(model.Name) || gender.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower());
    }
}
