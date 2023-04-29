using MediatR;
using NomeDoProjeto.Domain.Generic.Queries;
using NomeDoProjeto.Exceptions;
using NomeDoProjeto.Repository;

namespace NomeDoProjeto.Handlers.Generic
{
    public class FindByIdQueryHandler<TEntity, TFindByIdQuery> : IRequestHandler<TFindByIdQuery, TEntity>
        where TEntity : class, new()
        where TFindByIdQuery : FindByIdQuery<TEntity>, new()
    {
        private readonly ICrudRepository<TEntity> _repository;

        public FindByIdQueryHandler(ICrudRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> Handle(TFindByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await this._repository.FindByIdAsync(request.Id);
            if (entity == null)
                throw new NotFoundException("Registro não encontrado.");
            return entity;
        }
    }
}