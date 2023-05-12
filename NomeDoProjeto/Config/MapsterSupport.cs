using System.Reflection;
using Mapster;

namespace NomeDoProjeto.Config;

public static class MapsterSupport
{
    public static void AddMapsterSupport(this IServiceCollection services, Assembly assembly)
    {
        TypeAdapterConfig.GlobalSettings.Scan(assembly);
    }
}