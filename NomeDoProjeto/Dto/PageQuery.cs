using System.Linq.Expressions;

namespace NomeDoProjeto.Dto
{
    public class PageQuery<T> : IPageQuery<T>
    {
        public Expression<Func<T, bool>>? Filter { get; set; }
        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string IncludeProperties { get; set; } = "";
    }
}