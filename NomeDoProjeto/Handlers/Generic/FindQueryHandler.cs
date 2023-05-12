using MediatR;
using Microsoft.Extensions.Localization;
using NomeDoProjeto.Domain.Generic.Queries;
using NomeDoProjeto.Dto;
using NomeDoProjeto.Repository;
using NomeDoProjeto.Resources;

namespace NomeDoProjeto.Handlers.Generic
{
    public class FindQueryHandler<TEntity, TRequest, TResponse> : IRequestHandler<TRequest, Page<TResponse>>
        where TEntity : class
        where TRequest : FindQuery<TResponse>
        where TResponse : class
    {
        private readonly ICrudRepository<TEntity> _repository;
        private readonly IStringLocalizer<PropertiesStringLocalizer> _localizer;

        public FindQueryHandler(ICrudRepository<TEntity> repository, IStringLocalizer<PropertiesStringLocalizer> localizer)
        {
            _repository = repository;
            _localizer = localizer;
        }

        public async Task<Page<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            // var entity = await this._repository.FindAsync(request);
            // return entity;
            Console.WriteLine(this._localizer["InternalServerErrorErrorMessage"]);
            return null;
        }
    }
}