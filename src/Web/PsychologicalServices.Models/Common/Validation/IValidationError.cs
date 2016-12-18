using System;

namespace PsychologicalServices.Models.Common.Validation
{
    public interface IValidationError
    {
        string Property { get; }

        string Message { get; }
    }
}
