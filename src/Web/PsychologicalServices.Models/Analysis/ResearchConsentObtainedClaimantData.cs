using System;

namespace PsychologicalServices.Models.Analysis
{
    public class ResearchConsentObtainedClaimantData
    {
        public int ClaimantId { get; set; }

        public string FirstName { get; set; }
	
        public string LastName { get; set; }

        public string Gender { get; set; }
	
        public DateTimeOffset DateOfBirth { get; set; }

        public string ReferralSource { get; set; }

        public DateTimeOffset AppointmentTime { get; set; }
    }
}
