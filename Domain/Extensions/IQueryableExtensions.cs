using Library.Domain.Common;
using Library.Domain.Interfaces.Pagination;

namespace Library.Domain.Extensions
{
    public static class IQueryableExtensions
    {
        public static async Task<IPagedList<TEntity>> ToPagedListAsync<TEntity>(this IQueryable<TEntity> query, int pageNumber, int pageSize) where TEntity : class
        {
            var totalItemCount = query.Count();
            var items = await Task.FromResult(query.Skip(pageSize * (pageNumber - 1)).Take(pageSize == 0 ? totalItemCount : pageSize));
            var pageCount = (double)totalItemCount / pageSize;
            var totalPages = (int)Math.Ceiling(pageCount);
            return new PagedList<TEntity>(pageNumber, pageSize, totalItemCount, totalPages, items.ToList());
        }
    }
}
