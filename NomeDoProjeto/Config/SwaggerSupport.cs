namespace NomeDoProjeto.Config;

using Microsoft.OpenApi.Models;

public static class SwaggerSupport
{
    public static void AddSwaggerSupport(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
        });
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
    }

    public static void AddSwaggerSupport(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
            c.RoutePrefix = string.Empty;
        });
    }
}