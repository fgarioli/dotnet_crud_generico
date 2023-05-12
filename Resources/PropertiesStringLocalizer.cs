namespace NomeDoProjeto.Resources;

using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class PropertiesStringLocalizer : IStringLocalizer
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string _resourcesDirectoryPath;
    private readonly Dictionary<string, Dictionary<string, string>> _cache;

    public PropertiesStringLocalizer(IHttpContextAccessor httpContextAccessor, string resourcesDirectoryPath)
    {
        _httpContextAccessor = httpContextAccessor;
        _resourcesDirectoryPath = resourcesDirectoryPath;
        _cache = new Dictionary<string, Dictionary<string, string>>();
    }

    public LocalizedString this[string name] => GetLocalizedString(name);

    public LocalizedString this[string name, params object[] arguments] => GetLocalizedString(name, arguments);

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        var resources = new Dictionary<string, LocalizedString>();

        foreach (var kvp in _cache)
        {
            foreach (var resource in kvp.Value)
            {
                if (!resources.ContainsKey(resource.Key))
                {
                    resources.Add(resource.Key, new LocalizedString(resource.Key, resource.Value));
                }
            }
        }

        return resources.Values;
    }

    public IStringLocalizer WithCulture(CultureInfo culture)
    {
        return new PropertiesStringLocalizer(_httpContextAccessor, _resourcesDirectoryPath);
    }

    private LocalizedString GetLocalizedString(string name, params object[] arguments)
    {
        var culture = GetCurrentCulture();
        if (!_cache.ContainsKey(name))
        {
            LoadResource(culture);
        }

        var cultureName = culture.Name;
        var value = _cache[cultureName].TryGetValue(name, out string localizedString)
            ? localizedString
            : name;

        return new LocalizedString(name, string.Format(value, arguments));
    }

    private void LoadResource(CultureInfo currentCulture)
    {
        var cultureName = currentCulture.Name;
        var filePath = Path.Combine(_resourcesDirectoryPath, $"messages.{cultureName}.properties");

        if (!File.Exists(filePath))
        {
            return;
        }

        using (var streamReader = new StreamReader(filePath))
        {
            var resourceContent = streamReader.ReadToEnd();
            _cache[cultureName] = ParseResourceContent(resourceContent);
        }
    }

    private Dictionary<string, string> ParseResourceContent(string resourceContent)
    {
        var resources = new Dictionary<string, string>();

        foreach (var line in resourceContent.Split('\n'))
        {
            if (line.StartsWith("#") || string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            var keyValuePair = line.Split('=', 2);

            if (keyValuePair.Length != 2)
            {
                continue;
            }

            resources[keyValuePair[0].Trim()] = keyValuePair[1].Trim();
        }

        return resources;
    }

    public CultureInfo GetCurrentCulture()
    {
        var feature = _httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();
        var culture = feature.RequestCulture.Culture;

        return culture;
    }
}