using NomeDoProjeto.Dto;

namespace NomeDoProjeto.Services
{
    public interface ICrudService<T> where T : class
    {
        void Create(T obj);
        Page<T> Read();
        T? Read(int id);
        void Update(T obj);
        void Delete(int id);
    }
}