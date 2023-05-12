namespace NomeDoProjeto.Context;

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NomeDoProjeto.Utils;

public static class ModelBuilderExtensions
{
    public static void RegisterAllEntities(this ModelBuilder modelBuilder, Assembly assembly)
    {
        var classesToRegister = assembly.GetTypes()
                .Where(x => x.GetCustomAttributes<Entity>().Any());

        foreach (var classType in classesToRegister)
        {
            var attribute = classType.GetCustomAttribute<Entity>();
            if (attribute == null)
                continue;

            modelBuilder.Entity(classType);
        }
    }
}