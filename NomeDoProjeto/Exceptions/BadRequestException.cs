namespace NomeDoProjeto.Exceptions
{
    public class BadRequestException : HttpException
    {
        public BadRequestException(string message = "Bad Request") : base(400, message)
        {
        }
    }
}