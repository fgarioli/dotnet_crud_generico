using MediatR;

namespace NomeDoProjeto.Domain.Generic.Queries;

public class FindByIdQuery<T> : IRequest<T> where T : class
{
    public int Id { get; set; }

    public FindByIdQuery(int id) => this.Id = id;
}