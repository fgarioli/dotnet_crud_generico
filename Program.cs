namespace NomeDoProjeto
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        public static void Main(string[] args)
        {
            DotNetEnv.Env.Load("./.env");
            Console.WriteLine(Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"));
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(services =>
                {
                    services.AddRouting();
                });
    }
}

// public static void Main(string[] args)
// {
//     DotNetEnv.Env.Load("./.env");
//     var app = CreateHostBuilder(args).Build();
//     if (app.Environment.IsDevelopment())
//     {
//         app.UseSwagger();
//         app.UseSwaggerUI();
//     }

//     app.UseHttpsRedirection();
//     app.UseAuthorization();
//     app.MapControllers();
//     app.Run();
// }
// public static WebApplicationBuilder CreateHostBuilder(string[] args)
// {
//     var builder = WebApplication.CreateBuilder(args);
//     builder.Services.AddControllers();
//     // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//     builder.Services.AddEndpointsApiExplorer();
//     builder.Services.AddSwaggerGen();
//     builder.Services.AddSingleton<ISessionFactory>(factory =>
//     {
//         var dbHost = "localhost";
//         var dbName = "nombre_base_datos";
//         var dbUser = "usuario";
//         var dbPassword = "contraseña";
//         var dbPort = "5432";

//         return Fluently.Configure()
//             .Database(FluentNHibernate.Cfg.Db.PostgreSQLConfiguration.PostgreSQL82
//                 .ConnectionString($"Server={dbHost};Port={dbPort};Database={dbName};User Id={dbUser};Password={dbPassword};")
//                 .FormatSql()
//                 .ShowSql()
//             )
//             .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
//             .BuildSessionFactory();
//     });

//     return builder;
// }