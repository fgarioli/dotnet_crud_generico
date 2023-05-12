namespace NomeDoProjeto.Domain.Usuario.Command;

using System.ComponentModel.DataAnnotations;
using NomeDoProjeto.Domain.Generic.Commands;

public class UsuarioUpdateCommand : UpdateCommand<UsuarioEntity>
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Email { get; set; }
}