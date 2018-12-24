using System;

namespace PsychologicalServices.Models.Claims
{
    public class Claim
    {
        public int ClaimId { get; set; }

        public DateTimeOffset? DateOfLoss { get; set; }

        public string ClaimNumber { get; set; }

        public string Lawyer { get; set; }

        public string InsuranceCompany { get; set; }

        public bool IsNew()
        {
            return ClaimId == 0;
        }
    }
}
