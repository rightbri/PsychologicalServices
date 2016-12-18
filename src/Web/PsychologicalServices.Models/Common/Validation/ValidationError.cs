using System;

namespace PsychologicalServices.Models.Common.Validation
{
    public class ValidationError : IValidationError
    {
        public string Property { get; set; }

        public string Message { get; set; }
    }
}
