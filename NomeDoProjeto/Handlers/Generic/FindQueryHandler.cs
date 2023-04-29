using MediatR;
using NomeDoProjeto.Domain.Generic.Queries;
using NomeDoProjeto.Dto;
using NomeDoProjeto.Repository;

namespace NomeDoProjeto.Handlers.Generic
{
    public class FindQueryHandler<TEntity, TFindQuery> : IRequestHandler<TFindQuery, Page<TEntity>>
        where TEntity : class, new()
        where TFindQuery : FindQuery<TEntity>, new()
    {
        private readonly ICrudRepository<TEntity> _repository;

        public FindQueryHandler(ICrudRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Page<TEntity>> Handle(TFindQuery request, CancellationToken cancellationToken)
        {
            // var entity = await this._repository.FindAsync(request);
            // return entity;
            return null;
        }
    }
}