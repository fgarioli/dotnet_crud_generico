namespace NomeDoProjeto.Exceptions;

using System.Net;

public class NotFoundException : HttpException
{
    public NotFoundException(string message = "Not Found") : base(HttpStatusCode.NotFound, message)
    {
    }
}