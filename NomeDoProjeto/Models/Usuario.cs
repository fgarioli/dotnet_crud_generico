using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NomeDoProjeto.Models
{
    [Table("usuario")]
    public class Usuario : IAutoMap
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("nome", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

        [Column("senha")]
        [Required(ErrorMessage = "O email é obrigatório")]
        public string Senha { get; set; }

        public Usuario(int id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public static void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.UseSerialColumns();
    }
}