using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using NomeDoProjeto.Controllers;
using NomeDoProjeto.Domain.Generic.Commands;
using NomeDoProjeto.Domain.Generic.Queries;

namespace NomeDoProjeto.Utils
{
    public class ApiResourceFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var currentAssembly = typeof(ApiResourceFeatureProvider).Assembly;
            var candidates = currentAssembly.GetExportedTypes().Where(x => x.GetCustomAttributes<ApiResource>().Any());

            foreach (var candidate in candidates)
            {
                var attribute = candidate.GetCustomAttribute<ApiResource>();
                if (attribute == null)
                    continue;

                var deleteCommand = attribute.DeleteCommand ?? typeof(DeleteCommand<>).MakeGenericType(candidate);
                var findByIdQuery = attribute.FindByIdQuery ?? typeof(FindByIdQuery<>).MakeGenericType(candidate);
                var findQuery = attribute.FindQuery ?? typeof(FindQuery<>).MakeGenericType(candidate);
                Type[] typeArgs = { candidate, attribute.CreateCommand, attribute.UpdateCommand, deleteCommand, findByIdQuery, findQuery };
                var type = typeof(GenericController<,,,,,>)
                        .MakeGenericType(typeArgs)
                        .GetTypeInfo();

                feature.Controllers.Add(type);
            }
        }
    }
}