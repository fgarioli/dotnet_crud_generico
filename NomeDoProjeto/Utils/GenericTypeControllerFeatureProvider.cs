using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using NomeDoProjeto.Controllers;

namespace NomeDoProjeto.Utils
{
    public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var currentAssembly = typeof(GenericTypeControllerFeatureProvider).Assembly;
            var candidates = currentAssembly.GetExportedTypes().Where(x => x.GetCustomAttributes<GeneratedControllerAttribute>().Any());

            foreach (var candidate in candidates)
            {
                var attribute = candidate.GetCustomAttribute<GeneratedControllerAttribute>();
                Type[] typeArgs = { candidate, attribute.CreateCommand, attribute.UpdateCommand, attribute.DeleteCommand, attribute.FindByIdQuery, attribute.FindQuery };
                var type = typeof(BaseController<,,,,,>)
                        .MakeGenericType(typeArgs)
                        .GetTypeInfo();

                feature.Controllers.Add(type);
            }
        }
    }
}