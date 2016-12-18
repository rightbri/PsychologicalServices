using PsychologicalServices.Models.Reports;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Assessments
{
    public class AssessmentType
    {
        public int AssessmentTypeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<ReportType> ReportTypes { get; set; }

        public bool IsNew()
        {
            return AssessmentTypeId == 0;
        }
    }
}
