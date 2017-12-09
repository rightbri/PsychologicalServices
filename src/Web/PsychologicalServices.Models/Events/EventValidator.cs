using System;
using System.Collections.Generic;
using System.Linq;
using PsychologicalServices.Models.Common.Validation;

namespace PsychologicalServices.Models.Events
{
    public class EventValidator : IEventValidator
    {
        private readonly IEventRepository _eventRepository = null;

        public EventValidator(
            IEventRepository eventRepository
        )
        {
            _eventRepository = eventRepository;
        }

        public IValidationResult Validate(Event item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (string.IsNullOrWhiteSpace(item.Description))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Description", Message = "Event Description is required" }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
