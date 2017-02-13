using System;

namespace PsychologicalServices.Models.Common.Validation
{
    public class ValidationError : IValidationError
    {
        public string PropertyName { get; set; }
        
        public string Message { get; set; }
    }
}
