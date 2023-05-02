using NomeDoProjeto.Domain.Generic.Commands;
using NomeDoProjeto.Domain.Generic.Queries;

namespace NomeDoProjeto.Utils
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GeneratedControllerAttribute : Attribute
    {
        public Type CreateCommand { get; set; }
        public Type UpdateCommand { get; set; }
        public Type? DeleteCommand { get; set; } = null;
        public Type? FindByIdQuery { get; set; } = null;
        public Type? FindQuery { get; set; } = null;
        public string Route { get; set; }

        public GeneratedControllerAttribute(string route, Type createCommand, Type updateCommand, Type? deleteCommand = null, Type? findByIdQuery = null, Type? findQuery = null)
        {
            this.Route = route;
            this.CreateCommand = createCommand;
            this.UpdateCommand = updateCommand;
            this.DeleteCommand = deleteCommand ;
            this.FindByIdQuery = findByIdQuery;
            this.FindQuery = findQuery;
        }
    }
}