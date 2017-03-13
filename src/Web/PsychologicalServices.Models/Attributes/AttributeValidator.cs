using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Attributes
{
    public class AttributeValidator : IAttributeValidator
    {
        private readonly IAttributeRepository _attributeRepository = null;

        public AttributeValidator(
            IAttributeRepository attributeRepository
        )
        {
            _attributeRepository = attributeRepository;
        }

        public IValidationResult Validate(Models.Attributes.Attribute item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Name", Message = "Attribute name is required" }
                );
            }
            
            if (null != item.AttributeType)
            {
                var attributeType = _attributeRepository.GetAttributeType(item.AttributeType.AttributeTypeId);
                if (null == attributeType)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "AttributeTypeId", Message = "Attribute type is required" }
                    );
                }
            }
            else
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "AttributeType", Message = "Attribute type is required" }
                );
            }
            
            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
