using System;

namespace PsychologicalServices.Models.Assessments
{
    public class AssessmentTestingResults
    {
        public string Name { get; set; }

        public string Responses { get; set; }

        public Assessment Assessment { get; set; }
    }
}
