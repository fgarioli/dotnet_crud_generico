using NomeDoProjeto.Context;

namespace NomeDoProjeto.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void BeginTransaction() => this._dbContext.Database.BeginTransaction();

        public void Commit() => this._dbContext.SaveChanges();

        public void Rollback() => this._dbContext.Database.RollbackTransaction();
    }
}