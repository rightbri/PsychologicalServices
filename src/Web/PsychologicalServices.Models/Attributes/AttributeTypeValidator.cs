using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Attributes
{
    public class AttributeTypeValidator : IAttributeTypeValidator
    {
        private readonly IAttributeRepository _attributeRepository = null;

        public AttributeTypeValidator(
            IAttributeRepository attributeRepository
        )
        {
            _attributeRepository = attributeRepository;
        }

        public IValidationResult Validate(AttributeType item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Name", Message = "Attribute type name is required" }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
