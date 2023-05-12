using System.ComponentModel.DataAnnotations;
using Mapster;

namespace NomeDoProjeto.Dto.Exceptions;

public class Violation
{
    public string PropertyName { get; }
    public string Message { get; }

    public Violation(string propertyName, string message)
    {
        this.PropertyName = propertyName;
        this.Message = message;
    }

    // public static TypeAdapterConfig GetMapsterConfig()
    // {
    //     return new TypeAdapterConfig()
    //         .NewConfig<Violation, ValidationResult>()
    //             .Map(dest => dest.Message, src => src.Message)
    //             .Map(dest => dest.Violations, src => src.Violations)
    //             .Config;
    // }
}