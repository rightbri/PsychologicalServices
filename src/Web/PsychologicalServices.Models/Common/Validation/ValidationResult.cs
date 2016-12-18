using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Common.Validation
{
    public class ValidationResult : IValidationResult
    {
        public ValidationResult()
        {
            ValidationErrors = new List<IValidationError>();
        }

        public bool IsValid { get; set; }

        public List<IValidationError> ValidationErrors { get; set; }
    }
}
