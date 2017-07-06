using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Attributes
{
    public class AttributeSearchCriteria
    {
        public string Name { get; set; }

        public IEnumerable<int> AttributeTypeIds { get; set; }

        public IEnumerable<int> CompanyIds { get; set; }

        public IEnumerable<int> AssessmentTypeIds { get; set; }

        public bool? IsActive { get; set; }
    }
}
