namespace NomeDoProjeto.Config;

using System.Reflection;
using MediatR;
using NomeDoProjeto.Domain.Generic.Commands;
using NomeDoProjeto.Domain.Generic.Queries;
using NomeDoProjeto.Dto;
using NomeDoProjeto.Handlers.Generic;
using NomeDoProjeto.Utils;

public static class DefaultHandlersResolver
{
    public static void AddDefaultHandlers(this IServiceCollection services, Assembly assembly)
    {
        // Obtem todas as classes anotadas com a annotation AutoRegisterAttribute
        var classesToRegister = assembly.GetTypes()
            .Where(x => x.GetCustomAttributes<ApiResource>().Any());

        foreach (var classType in classesToRegister)
        {
            var attribute = classType.GetCustomAttribute<ApiResource>();
            if (attribute == null)
                continue;

            Type createTypeHandler = typeof(IRequestHandler<,>).MakeGenericType(attribute.CreateCommand, classType);
            Type createType = typeof(CreateHandler<,,>).MakeGenericType(classType, attribute.CreateCommand, classType);
            services.AddScoped(createTypeHandler, createType);

            Type updateTypeHandler = typeof(IRequestHandler<,>).MakeGenericType(attribute.UpdateCommand, classType);
            Type updateType = typeof(UpdateHandler<,,>).MakeGenericType(classType, attribute.UpdateCommand, classType);
            services.AddScoped(updateTypeHandler, updateType);

            Type deleteCommand = attribute.DeleteCommand ?? typeof(DeleteCommand<>).MakeGenericType(typeof(bool));
            Type deleteTypeHandler = typeof(IRequestHandler<,>).MakeGenericType(deleteCommand, typeof(bool));
            Type deleteType = typeof(DeleteHandler<,>).MakeGenericType(classType, deleteCommand);
            services.AddScoped(deleteTypeHandler, deleteType);

            Type findByIdQuery = attribute.FindByIdQuery ?? typeof(FindByIdQuery<>).MakeGenericType(classType);
            Type findByIdTypeHandler = typeof(IRequestHandler<,>).MakeGenericType(findByIdQuery, classType);
            Type findByIdType = typeof(FindByIdQueryHandler<,,>).MakeGenericType(classType, findByIdQuery, classType);
            services.AddScoped(findByIdTypeHandler, findByIdType);

            Type findQuery = attribute.FindQuery ?? typeof(FindQuery<>).MakeGenericType(classType);
            Type pageType = typeof(Page<>).MakeGenericType(classType);
            Type findTypeHandler = typeof(IRequestHandler<,>).MakeGenericType(findQuery, pageType);
            Type findType = typeof(FindQueryHandler<,,>).MakeGenericType(classType, findQuery, classType);
            services.AddScoped(findTypeHandler, findType);
        }
    }

}