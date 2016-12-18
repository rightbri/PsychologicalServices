using System;

namespace PsychologicalServices.Models.Assessments
{
    public class AssessmentTypeNotFoundException : Exception
    {
        private const string MessageFormat = "Assessment type {0} was not found";

        public AssessmentTypeNotFoundException(int assessmentTypeId)
            : base(string.Format(MessageFormat, assessmentTypeId))
        {
        }
    }
}
