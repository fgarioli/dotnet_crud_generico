namespace NomeDoProjeto.Dto.Exceptions
{
    public class JsonException
    {
        public string Message { get; }

        public JsonException(string message)
        {
            this.Message = message;
        }
    }
}