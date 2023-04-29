using NomeDoProjeto.Dto;
using NomeDoProjeto.UnitOfWork;

namespace NomeDoProjeto.Repository
{
    public interface ICrudRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; }
        Task AddAsync(T entity);
        void Update(T entity);
        void Merge(T entity, T requestEntity);
        void Delete(T entity);
        Task<T?> FindByIdAsync(int id);
        Task<Page<T>> FindAsync(IPageQuery<T> pageQuery);
    }
}