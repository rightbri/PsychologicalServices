using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.CalendarNotes
{
    public class CalendarNoteValidator : ICalendarNoteValidator
    {
        public IValidationResult Validate(CalendarNote item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (string.IsNullOrWhiteSpace(item.Note.NoteText))
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "Note.NoteText", Message = "Note text is required" }
                );
            }

            if (item.FromDate.HasValue && item.ToDate.HasValue && item.FromDate.Value > item.ToDate.Value)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "ToDate", Message = "To-Date must be after From-Date" }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
