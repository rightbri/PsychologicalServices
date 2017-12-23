using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Analysis
{
    public class AssessmentTypeCountDataSearchCriteria
    {
        public IEnumerable<int> AssessmentTypeIds { get; set; }

        public DateTimeOffset AppointmentTimeMin { get; set; }

        public DateTimeOffset AppointmentTimeMax { get; set; }
    }
}
