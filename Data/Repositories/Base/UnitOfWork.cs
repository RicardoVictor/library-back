using Library.Domain.Interfaces.Repositories.Base;
using Libraty.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Library.Data.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DefaultContext _context;
        private IDbContextTransaction _transaction;

        #region Repositories

        #endregion

        #region Interfaces

        #endregion

        public UnitOfWork(DefaultContext context)
        {
            _context = context;
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch
            {
                await _transaction.RollbackAsync();
                throw;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            await _transaction.RollbackAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
