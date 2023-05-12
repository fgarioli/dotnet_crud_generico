namespace NomeDoProjeto.UnitOfWork;

using Microsoft.EntityFrameworkCore;

public interface IUnitOfWork : IDisposable
{
    public DbContext Context { get; }
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}