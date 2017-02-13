using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Claims
{
    public class MedRehabValidator : IMedRehabValidator
    {
        public IValidationResult Validate(MedRehab item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (item.Amount < 0)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Amount", Message = "Amount must be greater than or equal to zero." }
                );
            }

            if (string.IsNullOrWhiteSpace(item.Description))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Description", Message = "Please enter a description" }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
