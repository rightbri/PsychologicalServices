using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Analysis
{
    public class AssessmentTypeCountSearchCriteria
    {
        public IEnumerable<int> AssessmentTypeIds { get; set; }

        public int Year { get; set; }

        public int CompanyId { get; set; }
    }
}
