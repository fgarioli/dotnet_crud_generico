namespace NomeDoProjeto.Resources;

using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

public class PropertiesStringLocalizerFactory : IStringLocalizerFactory
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string _resourcesDirectoryPath;

    public PropertiesStringLocalizerFactory(IHttpContextAccessor httpContextAccessor, IOptions<LocalizationOptions> options)
    {
        _httpContextAccessor = httpContextAccessor;
        _resourcesDirectoryPath = options.Value.ResourcesPath;
    }

    public IStringLocalizer Create(Type resourceSource)
    {
        return new PropertiesStringLocalizer(_httpContextAccessor, _resourcesDirectoryPath);
    }

    public IStringLocalizer Create(string baseName, string location)
    {
        return new PropertiesStringLocalizer(_httpContextAccessor, _resourcesDirectoryPath);
    }
}