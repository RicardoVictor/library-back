using Library.Domain.Entities;
using Library.Domain.Interfaces.Pagination;
using Library.Domain.Interfaces.Repositories.Base;
using Library.Domain.Model;

namespace Library.Domain.Interfaces.Repositories
{
    public interface IGenderRepository : IBaseRepository<Gender>
    {
        Task<IPagedList<Gender>> GetPagedAsync(GenderFilterModel filter);
        Task<IEnumerable<Gender>> GetFilteredAsync(GenderFilterModel filter);
    }
}
