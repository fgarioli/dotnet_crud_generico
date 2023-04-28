using System.Net;

namespace NomeDoProjeto.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpException ex)
            {
                // Defina o status da resposta
                context.Response.StatusCode = ex.HttpStatusCode;

                // Escreva a mensagem de erro na resposta
                await context.Response.WriteAsync(ex.Message);
            }
            // catch (Exception ex)
            // {
            //     context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //     await context.Response.WriteAsync(ex.Message);
            // }
        }
    }
}