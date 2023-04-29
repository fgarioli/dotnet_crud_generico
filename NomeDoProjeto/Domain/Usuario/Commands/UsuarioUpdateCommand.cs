using System.ComponentModel.DataAnnotations;
using MediatR;
using NomeDoProjeto.Domain.Generic.Commands;

namespace NomeDoProjeto.Domain.Usuario.Command
{
    public class UsuarioUpdateCommand : UpdateCommand<UsuarioEntity>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }
    }
}