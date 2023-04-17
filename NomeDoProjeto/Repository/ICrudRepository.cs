using NomeDoProjeto.Dto;

namespace NomeDoProjeto.Repository
{
    public interface ICrudRepository<TEntity> where TEntity : class
    {
        void Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(object id);
        TEntity? Read(int id);
        Page<TEntity> Read(IPageQuery<TEntity> pageQuery);
    }
}