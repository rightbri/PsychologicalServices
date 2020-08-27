using System;

namespace PsychologicalServices.Models.Assessments
{
    public class AssessmentSearchResult
    {
        public int AssessmentId { get; set; }

        public string AssessmentType { get; set; }

        public string ReferralSource { get; set; }

        public string Claimant { get; set; }

        public int AppointmentId { get; set; }

        public DateTimeOffset AppointmentTime { get; set; }
    }
}
