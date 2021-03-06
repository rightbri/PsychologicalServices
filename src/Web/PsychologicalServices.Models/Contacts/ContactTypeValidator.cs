﻿using System;
using System.Collections.Generic;
using System.Linq;
using PsychologicalServices.Models.Common.Validation;

namespace PsychologicalServices.Models.Contacts
{
    public class ContactTypeValidator : IContactTypeValidator
    {
        public IValidationResult Validate(ContactType item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Name", Message = "Name is required" }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
