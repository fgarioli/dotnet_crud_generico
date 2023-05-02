using MediatR;
using NomeDoProjeto.Domain.Generic.Queries;
using NomeDoProjeto.Dto;
using NomeDoProjeto.Repository;

namespace NomeDoProjeto.Handlers.Generic
{
    public class FindQueryHandler<TEntity, TRequest, TResponse> : IRequestHandler<TRequest, Page<TResponse>>
        where TEntity : class
        where TRequest : FindQuery<TResponse>
        where TResponse : class
    {
        private readonly ICrudRepository<TEntity> _repository;

        public FindQueryHandler(ICrudRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Page<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            // var entity = await this._repository.FindAsync(request);
            // return entity;
            return null;
        }
    }
}