using Microsoft.EntityFrameworkCore;

namespace NomeDoProjeto.Context;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var dbHost = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost";
        var dbName = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? throw new Exception("No database name provided");
        var dbUser = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? throw new Exception("No database user provided");
        var dbPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? throw new Exception("No database password provided");
        var dbPort = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432";
        var connectionString = $"Server={dbHost};Port={dbPort};Database={dbName};User Id={dbUser};Password={dbPassword};";
        options.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}