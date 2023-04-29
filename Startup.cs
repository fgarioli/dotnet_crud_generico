using Microsoft.OpenApi.Models;
using NomeDoProjeto.Context;
using NomeDoProjeto.Domain;
using NomeDoProjeto.Exceptions;
using NomeDoProjeto.Repository;
using NomeDoProjeto.UnitOfWork;
using NomeDoProjeto.Utils;

namespace NomeDoProjeto
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
            });
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            services.AddControllers();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly));
            services.
                AddMvc(o => o.Conventions.Add(
                    new GenericControllerRouteConvention()
                )).
                ConfigureApplicationPartManager(m =>
                    m.FeatureProviders.Add(new GenericTypeControllerFeatureProvider()
                ));

            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<ICrudRepository<UsuarioEntity>, CrudRepository<UsuarioEntity>>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseDeveloperExceptionPage();
        }
    }
}