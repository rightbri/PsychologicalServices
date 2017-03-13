using PsychologicalServices.Models.Companies;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Attributes
{
    public class Attribute
    {
        public int AttributeId { get; set; }

        public string Name { get; set; }

        public AttributeType AttributeType { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<Company> Companies { get; set; }

        public bool IsNew()
        {
            return AttributeId == 0;
        }
    }
}
