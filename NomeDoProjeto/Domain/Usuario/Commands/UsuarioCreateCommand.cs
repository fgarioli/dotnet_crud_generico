namespace NomeDoProjeto.Domain.Usuario.Command;

using System.ComponentModel.DataAnnotations;
using NomeDoProjeto.Domain.Generic.Commands;

public class UsuarioCreateCommand : CreateCommand<UsuarioEntity>
{
    [Required(ErrorMessage = "RequiredAttribute")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "RequiredAttribute")]
    public string Email { get; set; }

    [Required(ErrorMessage = "RequiredAttribute")]
    public string Senha { get; set; }
}