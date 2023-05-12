using System.ComponentModel.DataAnnotations;

namespace NomeDoProjeto.Utils
{
    public static class ValidationExtensions
    {
        public static IEnumerable<ValidationResult> getValidationErrors(this object obj)
        {
            var resultadoValidacao = new List<ValidationResult>();
            var contexto = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, contexto, resultadoValidacao, true);
            return resultadoValidacao;
        }
    }
}