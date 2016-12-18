using System;

namespace PsychologicalServices.Models.Common.Validation
{
    public interface IValidator<T>
    {
        IValidationResult Validate(T item);
    }
}
