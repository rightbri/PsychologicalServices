using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Notes
{
    public class NoteValidator : INoteValidator
    {
        public IValidationResult Validate(Note item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (string.IsNullOrWhiteSpace(item.NoteText))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "NoteText", Message = "Note text is required" }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
