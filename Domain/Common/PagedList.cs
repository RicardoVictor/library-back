using Library.Domain.Interfaces.Pagination;

namespace Library.Domain.Common
{
    public class PagedList<TEntity> : IPagedList<TEntity> where TEntity : class
    {
        public PagedList(int pageNumber, int pageSize, int totalItemCount, int totalPages, IEnumerable<TEntity> items)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItemCount;
            Items = items;
            TotalPages = totalPages;
        }

        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalPages { get; private set; }
        public IEnumerable<TEntity> Items { get; private set; }
    }
}
