using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Attributes
{
    public interface IAttributeRepository
    {
        Models.Attributes.Attribute GetAttribute(int id);

        AttributeType GetAttributeType(int id);

        IEnumerable<Models.Attributes.Attribute> SearchAttributes(AttributeSearchCriteria criteria);

        IEnumerable<AttributeType> GetAttributeTypes(bool? isActive = true);

        int SaveAttribute(Models.Attributes.Attribute attribute);

        int SaveAttributeType(AttributeType attributeType);
    }
}
