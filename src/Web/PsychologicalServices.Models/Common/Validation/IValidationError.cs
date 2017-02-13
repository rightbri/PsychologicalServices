using System;

namespace PsychologicalServices.Models.Common.Validation
{
    public interface IValidationError
    {
        string PropertyName { get; }
        
        string Message { get; }
    }
}
