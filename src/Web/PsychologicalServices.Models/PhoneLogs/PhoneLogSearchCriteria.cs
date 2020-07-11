using System;

namespace PsychologicalServices.Models.PhoneLogs
{
    public class PhoneLogSearchCriteria
    {
        public DateTimeOffset? StartCallTime { get; set; }

        public DateTimeOffset? EndCallTime { get; set; }

        public string CompanyName { get; set; }

        public string ClaimantFirstName { get; set; }

        public string ClaimantLastName { get; set; }
    }
}
