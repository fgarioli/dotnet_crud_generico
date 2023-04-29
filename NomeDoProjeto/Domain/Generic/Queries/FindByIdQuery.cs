using MediatR;

namespace NomeDoProjeto.Domain.Generic.Queries
{
    public interface FindByIdQuery<T> : IRequest<T> where T : class
    {
        int Id { get; set; }
    }
}