namespace NomeDoProjeto;

using MediatR;
using NomeDoProjeto.Config;
using NomeDoProjeto.Context;
using NomeDoProjeto.Repository;
using NomeDoProjeto.UnitOfWork;
using NomeDoProjeto.Utils;
using NomeDoProjeto.Utils.Filters;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var assembly = typeof(Startup).Assembly;
        services.AddSwaggerSupport();
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

        var mvcBuilder = services.AddControllers(options =>
        {
            options.Conventions.Add(new ApiResourceRouteConvention());
            options.Filters.Add(typeof(ValidateModelAttribute));
        })
        .ConfigureApplicationPartManager(m => m.FeatureProviders.Add(new ApiResourceFeatureProvider()));

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddMapsterSupport(assembly);

        services.AddLocalizationSupport(mvcBuilder);

        services.AddDefaultHandlers(assembly);

        services.AddDbContext<ApplicationDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        services.Scan(scan => scan
            .FromAssemblyOf<Startup>()
            .AddClasses(classes => classes.AssignableTo(typeof(ICrudRepository<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );

        // Adiciona localização dos arquivos de internacionalização
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.AddLocalizationSupport();
        app.AddSwaggerSupport();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();
    }
}