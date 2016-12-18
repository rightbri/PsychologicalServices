using System;

namespace PsychologicalServices.Models.Assessments
{
    public class AssessmentNotFoundException : Exception
    {
        private const string MessageFormat = "Assessment {0} was not found";

        public AssessmentNotFoundException(int assessmentId)
            : base(string.Format(MessageFormat, assessmentId))
        {
        }
    }
}
