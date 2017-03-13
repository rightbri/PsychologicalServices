using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Attributes
{
    public class AttributeService : IAttributeService
    {
        private readonly IAttributeRepository _attributeRepository = null;
        private readonly IAttributeValidator _attributeValidator = null;
        private readonly IAttributeTypeValidator _attributeTypeValidator = null;

        public AttributeService(
            IAttributeRepository attributeRepository,
            IAttributeValidator attributeValidator,
            IAttributeTypeValidator attributeTypeValidator
        )
        {
            _attributeRepository = attributeRepository;
            _attributeValidator = attributeValidator;
            _attributeTypeValidator = attributeTypeValidator;
        }

        public Attribute GetAttribute(int id)
        {
            var attribute = _attributeRepository.GetAttribute(id);

            return attribute;
        }

        public AttributeType GetAttributeType(int id)
        {
            var attributeType = _attributeRepository.GetAttributeType(id);

            return attributeType;
        }

        public IEnumerable<Models.Attributes.Attribute> SearchAttributes(AttributeSearchCriteria criteria)
        {
            var attributes = _attributeRepository.SearchAttributes(criteria);

            return attributes;
        }

        public IEnumerable<AttributeType> GetAttributeTypes(bool? isActive = true)
        {
            var attributeTypes = _attributeRepository.GetAttributeTypes(isActive);

            return attributeTypes;
        }

        public SaveResult<Models.Attributes.Attribute> SaveAttribute(Models.Attributes.Attribute attribute)
        {
            var result = new SaveResult<Models.Attributes.Attribute>();

            try
            {
                var validation = _attributeValidator.Validate(attribute);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _attributeRepository.SaveAttribute(attribute);

                    result.Item = _attributeRepository.GetAttribute(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                //TODO: log error
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public SaveResult<AttributeType> SaveAttributeType(AttributeType attributeType)
        {
            var result = new SaveResult<AttributeType>();

            try
            {
                var validation = _attributeTypeValidator.Validate(attributeType);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _attributeRepository.SaveAttributeType(attributeType);

                    result.Item = _attributeRepository.GetAttributeType(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                //TODO: log error
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
