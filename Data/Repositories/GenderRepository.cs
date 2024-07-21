using Library.Domain.Entities;
using Library.Domain.Helper;
using Library.Domain.Interfaces.Pagination;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Model;
using Library.Data;
using Library.Data.Repositories.Base;
using Libraty.Data;

namespace Library.Data.Repositories
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(DefaultContext context) : base(context)
        {
        }

        public async Task<IPagedList<Gender>> GetPagedAsync(GenderFilterModel filter)
            => await GetAsync(
                GenderFilterHelper.ApplyFilters(filter),
                u => u.Name,
                filter.PageNumber,
                filter.PageSize);

        public async Task<IEnumerable<Gender>> GetFilteredAsync(GenderFilterModel filter)
            => await GetAsync(GenderFilterHelper.ApplyFilters(filter));
    }
}
