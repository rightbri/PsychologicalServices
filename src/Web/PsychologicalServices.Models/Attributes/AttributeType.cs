using System;

namespace PsychologicalServices.Models.Attributes
{
    public class AttributeType
    {
        public int AttributeTypeId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return AttributeTypeId == 0;
        }
    }
}
