using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Users
{
    public class UnavailabilityValidator : IUnavailabilityValidator
    {
        public IValidationResult Validate(Unavailability item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (item.StartDate > item.EndDate)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "EndDate", Message = "Unavailability start date must be before end date" }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
