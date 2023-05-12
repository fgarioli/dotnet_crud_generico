namespace NomeDoProjeto.Domain.Generic.Commands;

using MediatR;

public interface CreateCommand<T> : IRequest<T> where T : class
{
}