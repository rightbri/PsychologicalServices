using System;
using System.Collections.Generic;
using System.Linq;
using PsychologicalServices.Models.Common.Validation;

namespace PsychologicalServices.Models.Documents
{
    public class DocumentValidator : IDocumentValidator
    {
        public IValidationResult Validate(Document item)
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

            if (item.Size < 0)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Size", Message = "Size cannot be less than zero" }
                );
            }

            if (null == item.Data)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Data", Message = "Data cannot be empty" }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
