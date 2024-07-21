namespace Library.Domain.Interfaces.Pagination
{
    public interface IPagedList<TEntity> where TEntity : class
    {
        int PageNumber { get; }
        int PageSize { get; }
        int TotalItems { get; }
        int TotalPages { get; }
        IEnumerable<TEntity> Items { get; }
    }
}
