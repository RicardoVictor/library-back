using System.Linq.Expressions;
using Library.Domain.Interfaces.Pagination;

namespace Library.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity obj);
        Task AddAsync(IEnumerable<TEntity> objs);
        void Update(TEntity obj);
        void UpdateRange(IEnumerable<TEntity> objs);
        void Remove(TEntity obj);
        void Remove(IEnumerable<TEntity> objs);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where);
        Task<IPagedList<TEntity>> GetAsync<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> order, int pageNumber, int pageSize);
        Task<IPagedList<TEntity>> GetAsync<TKey>(Expression<Func<TEntity, TKey>> order, int pageNumber, int pageSize);
    }
}
