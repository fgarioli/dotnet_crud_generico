namespace NomeDoProjeto.Domain.Usuario.Queries;

using NomeDoProjeto.Domain.Generic.Queries;

public class UsuarioFindQuery : FindQuery<UsuarioEntity>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string? OrderBy { get; set; }
    public string? OrderDirection { get; set; }
}