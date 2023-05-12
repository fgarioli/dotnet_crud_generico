namespace NomeDoProjeto.Domain.Generic.Queries;

using MediatR;
using NomeDoProjeto.Dto;

public interface FindQuery<T> : IRequest<Page<T>> where T : class
{
    int Page { get; set; }
    int PageSize { get; set; }
    string? OrderBy { get; set; }
    string? OrderDirection { get; set; }
}