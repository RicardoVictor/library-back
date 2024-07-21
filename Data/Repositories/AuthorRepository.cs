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
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(DefaultContext context) : base(context)
        {
        }

        public async Task<IPagedList<Author>> GetPagedAsync(AuthorFilterModel filter)
            => await GetAsync(
                AuthorFilterHelper.ApplyFilters(filter),
                u => u.Name,
                filter.PageNumber,
                filter.PageSize);

        public async Task<IEnumerable<Author>> GetFilteredAsync(AuthorFilterModel filter)
            => await GetAsync(AuthorFilterHelper.ApplyFilters(filter));

    }
}
