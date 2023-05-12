using System.Net;

namespace NomeDoProjeto.Exceptions;

public class HttpException : Exception
{
    public HttpStatusCode HttpStatusCode { get; set; }

    public HttpException(HttpStatusCode httpStatusCode, string message) : base(message)
    {
        this.HttpStatusCode = httpStatusCode;
    }
}