using Mapster;
using MediatR;
using NomeDoProjeto.Domain.Generic.Queries;
using NomeDoProjeto.Exceptions;
using NomeDoProjeto.Repository;

namespace NomeDoProjeto.Handlers.Generic
{
    public class FindByIdQueryHandler<TEntity, TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TEntity : class
        where TRequest : FindByIdQuery<TResponse>
        where TResponse : class
    {
        private readonly ICrudRepository<TEntity> _repository;

        public FindByIdQueryHandler(ICrudRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = await this._repository.FindByIdAsync(request.Id);
            if (entity == null)
                throw new NotFoundException("Registro não encontrado.");
            return entity.Adapt<TResponse>();
        }
    }
}