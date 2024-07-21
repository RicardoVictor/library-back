namespace Library.Domain.Interfaces.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task BeginTransactionAsync();
    }
}
