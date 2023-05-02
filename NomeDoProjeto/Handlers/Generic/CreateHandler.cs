using Mapster;
using MediatR;
using NomeDoProjeto.Domain.Generic.Commands;
using NomeDoProjeto.Repository;

namespace NomeDoProjeto.Handlers.Generic
{
    public class CreateHandler<TEntity, TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TEntity : class
        where TRequest : CreateCommand<TResponse>
        where TResponse : class
    {
        private readonly ICrudRepository<TEntity> _repository;

        public CreateHandler(ICrudRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = request.Adapt<TEntity>();

            await this._repository.AddAsync(entity);
            await this._repository.UnitOfWork.SaveChangesAsync();

            return entity.Adapt<TResponse>();
        }
    }
}