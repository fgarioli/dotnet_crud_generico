namespace NomeDoProjeto.Repository
{
    public interface ICrudRepository<T> where T : class
    {
        void Create(T obj);
        void Update(T entity, T updatedEntity);
        void Delete(object id);
        T? Read(int id);
        Page<T> Read(IPageQuery<T> pageQuery);
    }
}