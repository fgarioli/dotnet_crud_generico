using MediatR;

namespace NomeDoProjeto.Domain.Generic.Commands
{
    public interface CreateCommand<T> : IRequest<T> where T : class
    {
    }
}