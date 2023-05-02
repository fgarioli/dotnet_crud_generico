using MediatR;

namespace NomeDoProjeto.Domain.Generic.Commands;

public class DeleteCommand<T> : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteCommand(int id) => this.Id = id;
}