using Mapster;
using MediatR;
using NomeDoProjeto.Domain.Generic.Commands;
using NomeDoProjeto.Exceptions;
using NomeDoProjeto.Repository;

namespace NomeDoProjeto.Handlers.Generic
{
    public class UpdateHandler<TEntity, TUpdateCommand> : IRequestHandler<TUpdateCommand, TEntity>
        where TEntity : class, new()
        where TUpdateCommand : UpdateCommand<TEntity>, new()
    {
        private readonly ICrudRepository<TEntity> _repository;

        public UpdateHandler(ICrudRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> Handle(TUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await this._repository.FindByIdAsync(request.Id);
            if (entity == null)
                throw new NotFoundException();

            var updatedEntity = request.Adapt(entity);

            this._repository.Merge(entity, updatedEntity);
            await this._repository.UnitOfWork.SaveChangesAsync();

            return updatedEntity;
        }
    }
}