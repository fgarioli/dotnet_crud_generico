using Mapster;
using MediatR;
using NomeDoProjeto.Domain.Generic.Commands;
using NomeDoProjeto.Repository;

namespace NomeDoProjeto.Handlers.Generic
{
    public class CreateHandler<TEntity, TCreateCommand> : IRequestHandler<TCreateCommand, TEntity>
        where TEntity : class, new()
        where TCreateCommand : CreateCommand<TEntity>, new()
    {
        private readonly ICrudRepository<TEntity> _repository;

        public CreateHandler(ICrudRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> Handle(TCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Adapt<TEntity>();

            await this._repository.AddAsync(entity);
            await this._repository.UnitOfWork.SaveChangesAsync();

            return entity;
        }
    }
}