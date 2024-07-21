using Library.Domain.Entities;
using Library.Domain.Interfaces.Pagination;
using Library.Domain.Interfaces.Repositories.Base;
using Library.Domain.Model;

namespace Library.Domain.Interfaces.Repositories
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<IPagedList<Author>> GetPagedAsync(AuthorFilterModel filter);
        Task<IEnumerable<Author>> GetFilteredAsync(AuthorFilterModel filter);
    }
}
