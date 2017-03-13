using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Attributes
{
    public interface IAttributeService
    {
        Models.Attributes.Attribute GetAttribute(int id);

        AttributeType GetAttributeType(int id);

        IEnumerable<Models.Attributes.Attribute> SearchAttributes(AttributeSearchCriteria criteria);

        IEnumerable<AttributeType> GetAttributeTypes(bool? isActive = true);

        SaveResult<Models.Attributes.Attribute> SaveAttribute(Models.Attributes.Attribute attribute);

        SaveResult<AttributeType> SaveAttributeType(AttributeType attributeType);
    }
}
