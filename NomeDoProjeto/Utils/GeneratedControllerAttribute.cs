using NomeDoProjeto.Domain.Generic.Commands;
using NomeDoProjeto.Domain.Generic.Queries;

namespace NomeDoProjeto.Utils
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GeneratedControllerAttribute : Attribute
    {
        private Type _targetType;
        public Type CreateCommand { get; set; }
        public Type UpdateCommand { get; set; }
        public Type DeleteCommand { get; set; }
        public Type FindByIdQuery { get; set; }
        public Type FindQuery { get; set; }
        public string Route { get; set; }

        public GeneratedControllerAttribute(string route, Type createCommand, Type updateCommand, Type? deleteCommand = null, Type? findByIdQuery = null, Type? findQuery = null)
        {
            this.Route = route;
            this._targetType = createCommand.GetInterfaces().ElementAt(0).GetGenericArguments().ElementAt(0);
            this.CreateCommand = createCommand;
            this.UpdateCommand = updateCommand;
            this.DeleteCommand = deleteCommand ?? typeof(DeleteCommand<>).MakeGenericType(this._targetType);
            this.FindByIdQuery = findByIdQuery ?? typeof(FindByIdQuery<>).MakeGenericType(this._targetType);
            this.FindQuery = findQuery ?? typeof(FindQuery<>).MakeGenericType(this._targetType);
        }
    }
}