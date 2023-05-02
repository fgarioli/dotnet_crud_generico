using MediatR;

namespace NomeDoProjeto.Domain.Generic.Commands;

public interface UpdateCommand<T> : IRequest<T> where T : class
{
    public int Id { get; set; }
}