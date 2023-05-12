namespace NomeDoProjeto.Utils.Filters;

using System.Net;
using System.Web.Http.Filters;

public class ValidationExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(HttpActionExecutedContext context)
    {
        if (context.Exception is NotImplementedException)
        {
            context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
        }
    }
}