using System.Linq.Expressions;
using Library.Domain.Interfaces.Pagination;
using Library.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Library.Domain.Extensions;

namespace Library.Data.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public Task AddAsync(TEntity obj)
        {
            return _context.Set<TEntity>().AddAsync(obj).AsTask();
        }

        public Task AddAsync(IEnumerable<TEntity> objs)
        {
            return _context.Set<TEntity>().AddRangeAsync(objs);
        }

        public void Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
        }

        public void Remove(IEnumerable<TEntity> objs)
        {
            _context.Set<TEntity>().RemoveRange(objs);
        }

        public void Update(TEntity obj)
        {
            _context.Set<TEntity>().Update(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<TEntity> objs)
        {
            _context.Set<TEntity>().UpdateRange(objs);
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> where)
        {
            return _context.Set<TEntity>().AnyAsync(where);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public Task<TEntity> GetAsync(int id)
        {
            return _context.Set<TEntity>().FindAsync(id).AsTask();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _context.Set<TEntity>().Where(where).ToListAsync();
        }

        public Task<IPagedList<TEntity>> GetAsync<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> order, int pageNumber, int pageSize)
        {
            return _context.Set<TEntity>()
                .Where(where)
                .OrderBy(order)
                .ToPagedListAsync(pageNumber, pageSize);
        }

        public Task<IPagedList<TEntity>> GetAsync<TKey>(Expression<Func<TEntity, TKey>> order, int pageNumber, int pageSize)
        {
            return _context.Set<TEntity>()
               .OrderBy(order)
               .ToPagedListAsync(pageNumber, pageSize);
        }

        public async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(where);
        }

        public IQueryable<TEntity> Query
        {
            get { return _context.Set<TEntity>(); }
        }
    }
}
