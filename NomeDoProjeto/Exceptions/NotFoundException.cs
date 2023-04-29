namespace NomeDoProjeto.Exceptions
{
    public class NotFoundException : HttpException
    {
        public NotFoundException(string message = "Not Found") : base(404, message)
        {
        }
    }
}