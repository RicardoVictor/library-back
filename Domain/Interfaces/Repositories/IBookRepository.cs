using Library.Domain.Entities;
using Library.Domain.Interfaces.Pagination;
using Library.Domain.Interfaces.Repositories.Base;
using Library.Domain.Model;

namespace Library.Domain.Interfaces.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<IPagedList<Book>> GetPagedAsync(BookFilterModel filter);
        Task<IEnumerable<Book>> GetFilteredAsync(BookFilterModel filter);
    }
}
