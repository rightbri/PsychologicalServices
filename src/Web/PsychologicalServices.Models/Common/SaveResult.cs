using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Common
{
    public class SaveResult<T>
    {
        public bool IsSaved { get; set; }

        public bool IsError { get; set; }

        public string ErrorDetails { get; set; }

        public IValidationResult ValidationResult { get; set; }

        public T Item { get; set; }
    }
}
