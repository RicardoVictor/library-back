using Library.Domain.Entities;
using Library.Domain.Helper;
using Library.Domain.Interfaces.Pagination;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Model;
using Library.Data.Repositories.Base;
using Libraty.Data;

namespace Library.Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(DefaultContext context) : base(context)
        {
        }

        public async Task<IPagedList<Book>> GetPagedAsync(BookFilterModel filter)
            => await GetAsync(
                BookFilterHelper.ApplyFilters(filter),
                u => u.Name,
                filter.PageNumber,
                filter.PageSize);

        public async Task<IEnumerable<Book>> GetFilteredAsync(BookFilterModel filter)
            => await GetAsync(BookFilterHelper.ApplyFilters(filter));
    }
}
