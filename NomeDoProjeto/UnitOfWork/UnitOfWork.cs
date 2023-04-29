using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NomeDoProjeto.Context;

namespace NomeDoProjeto.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }
        private readonly ILogger<UnitOfWork> _logger;
        private bool _disposed;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ApplicationDbContext context, ILogger<UnitOfWork> logger)
        {
            Context = context;
            _logger = logger;
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving changes to the database.");
                throw;
            }
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("Transaction has already begun.");
            }

            _transaction = await Context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Transaction has not yet begun.");
            }

            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error committing the transaction.");
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                await _transaction.RollbackAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error rolling back the transaction.");
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Context.Dispose();
                _disposed = true;
            }

            GC.SuppressFinalize(this);
        }
    }
}