using Microsoft.EntityFrameworkCore;

namespace NomeDoProjeto.Models
{
    public interface IAutoMap
    {
        static abstract void OnModelCreating(ModelBuilder modelBuilder);
    }
}