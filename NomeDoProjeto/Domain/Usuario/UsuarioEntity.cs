using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NomeDoProjeto.Domain.Usuario.Command;
using NomeDoProjeto.Domain.Usuario.Queries;
using NomeDoProjeto.Utils;

namespace NomeDoProjeto.Domain
{
    [Table("usuario")]
    [GeneratedControllerAttribute("/usuario",
        createCommand: typeof(UsuarioCreateCommand),
        updateCommand: typeof(UsuarioUpdateCommand),
        findQuery: typeof(UsuarioFindQuery)
    )]
    public class UsuarioEntity
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("nome", TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        public UsuarioEntity(int id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}