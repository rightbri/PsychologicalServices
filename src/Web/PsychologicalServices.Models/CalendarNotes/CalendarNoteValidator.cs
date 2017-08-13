using PsychologicalServices.Models.Common.Validation;
using PsychologicalServices.Models.Notes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.CalendarNotes
{
    public class CalendarNoteValidator : ICalendarNoteValidator
    {
        private readonly INoteValidator _noteValidator = null;

        public CalendarNoteValidator(
            INoteValidator noteValidator
        )
        {
            _noteValidator = noteValidator;
        }

        public IValidationResult Validate(CalendarNote item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (item.FromDate > item.ToDate)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "ToDate", Message = "To-Date must be after From-Date" }
                );
            }

            result.ValidationErrors.AddRange(
                _noteValidator.Validate(item.Note).ValidationErrors
            );
            
            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
