using MediatR;

namespace NomeDoProjeto.Domain.Generic.Commands
{
    public interface DeleteCommand<TEntity> : IRequest<bool>
    {
        public int Id { get; set; }
    }
}