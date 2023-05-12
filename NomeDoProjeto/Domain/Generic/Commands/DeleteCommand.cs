namespace NomeDoProjeto.Domain.Generic.Commands;

using MediatR;

public class DeleteCommand<T> : IRequest<T>
{
    public int Id { get; set; }

    public DeleteCommand(int id) => this.Id = id;
}