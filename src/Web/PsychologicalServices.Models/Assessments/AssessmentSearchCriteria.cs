using System;

namespace PsychologicalServices.Models.Assessments
{
    public class AssessmentSearchCriteria
    {
        public int CompanyId { get; set; }

        public int? AssessmentId { get; set; }

        public int? ReferralSourceId { get; set; }

        public int? ClaimantId { get; set; }

        public DateTimeOffset? AppointmentTimeStart { get; set; }

        public DateTimeOffset? AppointmentTimeEnd { get; set; }

        public bool? NeedsStatusUpdate { get; set; }
    }
}
