using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Common.Validation
{
    public interface IValidationResult
    {
        bool IsValid { get; set; }

        List<IValidationError> ValidationErrors { get; set; }
    }
}
