namespace NomeDoProjeto.Utils
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GeneratedControllerAttribute : Attribute
    {
        public GeneratedControllerAttribute(string? route = null)
        {
            if (route != null)
                this.Route = route;
        }

        public string Route { get; set; }
    }
}