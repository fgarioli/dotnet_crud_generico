using Mapster;
using MediatR;
using NomeDoProjeto.Domain.Generic.Commands;
using NomeDoProjeto.Exceptions;
using NomeDoProjeto.Repository;

namespace NomeDoProjeto.Handlers.Generic
{
    public class UpdateHandler<TEntity, TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TEntity : class
        where TRequest : UpdateCommand<TResponse>
        where TResponse : class
    {
        private readonly ICrudRepository<TEntity> _repository;

        public UpdateHandler(ICrudRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = await this._repository.FindByIdAsync(request.Id);
            if (entity == null)
                throw new NotFoundException();

            var updatedEntity = request.Adapt(entity);

            this._repository.Merge(entity, updatedEntity);
            await this._repository.UnitOfWork.SaveChangesAsync();

            return updatedEntity.Adapt<TResponse>();
        }
    }
}