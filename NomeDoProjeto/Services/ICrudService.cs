using Newtonsoft.Json.Linq;
using NomeDoProjeto.Dto;
using NomeDoProjeto.Repository;

namespace NomeDoProjeto.Services
{
    public interface ICrudService<T> where T : class
    {
        void Create(T obj);
        Page<T> Read(IPageQueryDto<T> pageQuery);
        T? Read(int id);
        void Update(int id, T obj);
        void Delete(int id);
    }
}