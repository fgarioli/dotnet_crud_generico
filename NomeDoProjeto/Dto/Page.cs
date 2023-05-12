namespace NomeDoProjeto.Dto;

public class Page<T>
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int PageCount { get; set; }
    public int RowCount { get; set; }
    public IEnumerable<T> PageItems { get; set; } = new List<T>();
}