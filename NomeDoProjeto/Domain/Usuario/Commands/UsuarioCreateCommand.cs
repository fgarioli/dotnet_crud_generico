using System.ComponentModel.DataAnnotations;
using NomeDoProjeto.Domain.Generic.Commands;

namespace NomeDoProjeto.Domain.Usuario.Command
{
    public class UsuarioCreateCommand : CreateCommand<UsuarioEntity>
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}