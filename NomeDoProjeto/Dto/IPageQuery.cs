using System.Linq.Expressions;

namespace NomeDoProjeto.Dto
{
    public interface IPageQuery<T>
    {
        Expression<Func<T, bool>>? Filter { get; set; }
        Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }
        string IncludeProperties { get; set; }
    }
}