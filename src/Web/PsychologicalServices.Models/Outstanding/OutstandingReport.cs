using System;

namespace PsychologicalServices.Models.Outstanding
{
    public class OutstandingReport
    {
        public int AssessmentId { get; set; }

        public DateTimeOffset AppointmentTime { get; set; }

        public string Claimant { get; set; }

        public string ReferralSource { get; set; }
    }
}
