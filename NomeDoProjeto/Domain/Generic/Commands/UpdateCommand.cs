namespace NomeDoProjeto.Domain.Generic.Commands;

using MediatR;

public interface UpdateCommand<T> : IRequest<T> where T : class
{
    public int Id { get; set; }
}