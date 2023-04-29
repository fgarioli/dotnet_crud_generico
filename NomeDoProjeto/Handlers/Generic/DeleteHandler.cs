using MediatR;
using NomeDoProjeto.Domain.Generic.Commands;
using NomeDoProjeto.Exceptions;
using NomeDoProjeto.Repository;

namespace NomeDoProjeto.Handlers.Generic
{
    public class DeleteHandler<TEntity> : IRequestHandler<DeleteCommand<TEntity>, bool> where TEntity : class
    {
        private readonly ICrudRepository<TEntity> _repository;

        public DeleteHandler(ICrudRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var entity = await this._repository.FindByIdAsync(request.Id);
            if (entity == null)
                throw new NotFoundException();

            this._repository.Delete(entity);
            await this._repository.UnitOfWork.SaveChangesAsync();

            return true;
        }
    }
}