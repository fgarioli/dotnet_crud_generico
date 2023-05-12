namespace NomeDoProjeto.Config;

using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using NomeDoProjeto.Resources;
using NomeDoProjeto.Utils;

public static class LocalizationSupport
{
    public static void AddLocalizationSupport(this IServiceCollection services, IMvcBuilder mvcBuilder)
    {
        services.AddLocalization(o => { o.ResourcesPath = "Resources"; });
        services.AddSingleton<IStringLocalizerFactory>(provider =>
        {
            var localizationOptions = provider.GetRequiredService<IOptions<LocalizationOptions>>();
            var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
            return new PropertiesStringLocalizerFactory(httpContextAccessor, localizationOptions);
        });

        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[] { new CultureInfo("pt-BR"), new CultureInfo("en-US") };
            options.DefaultRequestCulture = new RequestCulture("pt-BR");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
            options.RequestCultureProviders.Insert(0, new AcceptLanguageHeaderRequestCultureProvider());
        });

        mvcBuilder.AddDataAnnotationsLocalization(options =>
            options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(PropertiesStringLocalizer)));
    }

    public static void AddLocalizationSupport(this IApplicationBuilder app)
    {
        app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);
    }

}