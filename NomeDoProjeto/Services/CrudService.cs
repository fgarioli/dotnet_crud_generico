using Newtonsoft.Json.Linq;
using NomeDoProjeto.Dto;
using NomeDoProjeto.Exceptions;
using NomeDoProjeto.Repository;
using NomeDoProjeto.UnitOfWork;

namespace NomeDoProjeto.Services
{
    public class CrudService<T> : ICrudService<T> where T : class
    {
        private readonly ICrudRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public CrudService(IUnitOfWork unitOfWork, ICrudRepository<T> repository)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
            this._repository = repository ?? throw new ArgumentNullException("repository");
        }

        public void Create(T obj)
        {
            this._repository.Create(obj);
            this._unitOfWork.Commit();
        }

        public void Update(int id, T obj)
        {
            var entity = this._repository.Read(id);
            if (entity == null)
                throw new NotFoundException();
            var originalJson = JObject.FromObject(entity);
            var jObject = JObject.FromObject(obj);
            originalJson.Merge(jObject, new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Merge
            });
            var updatedEntity = jObject.ToObject<T>();
            if (updatedEntity == null)
                throw new BadRequestException();
            this._repository.Update(entity, updatedEntity);
            this._unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            this._repository.Delete(id);
            this._unitOfWork.Commit();
        }

        public T? Read(int id)
        {
            return this._repository.Read(id);
        }

        public Page<T> Read(IPageQueryDto<T> pageQuery)
        {
            return this._repository.Read(new PageQuery<T>());
        }
    }
}