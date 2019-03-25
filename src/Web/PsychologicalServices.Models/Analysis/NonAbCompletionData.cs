using System;

namespace PsychologicalServices.Models.Analysis
{
    public class NonAbCompletionData
    {
        public int AssessmentId { get; set; }

	    public string ReferralType { get; set; }

	    public DateTimeOffset AppointmentTime { get; set; }

	    public int AppointmentYear { get; set; }

        public int AppointmentMonth { get; set; }

        public string AppointmentStatus { get; set; }

        public string ClaimantFirstName { get; set; }

	    public string ClaimantLastName { get; set; }
    }
}
