using System;

namespace PsychologicalServices.Models.Attributes
{
    public class AttributeValue
    {
        public Models.Attributes.Attribute Attribute { get; set; }

        public bool? Value { get; set; }
    }
}
