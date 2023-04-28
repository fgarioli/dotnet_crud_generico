namespace NomeDoProjeto.Exceptions
{
    public class HttpException : Exception
    {
        public int HttpStatusCode { get; set; }

        public HttpException(int httpStatusCode, string message) : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
        }
    }
}