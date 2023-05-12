using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace NomeDoProjeto.Utils
{
    public class ApiResourceRouteConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.IsGenericType)
            {
                var genericType = controller.ControllerType.GenericTypeArguments[0];
                var customNameAttribute = genericType.GetCustomAttribute<ApiResource>();
                controller.ControllerName = genericType.Name;
                if (customNameAttribute?.Route != null)
                {
                    controller.Selectors.Clear();
                    var routeAttribute = new RouteAttribute(customNameAttribute.Route);
                    var attributeModel = new AttributeRouteModel(routeAttribute);
                    var selectorModel = new SelectorModel { AttributeRouteModel = attributeModel };
                    controller.Selectors.Add(selectorModel);
                }
            }
        }
    }
}