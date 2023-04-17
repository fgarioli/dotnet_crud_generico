namespace NomeDoProjeto.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Rollback();
        void Commit();
    }
}