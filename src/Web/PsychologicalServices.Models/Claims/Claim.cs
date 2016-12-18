using System;

namespace PsychologicalServices.Models.Claims
{
    public class Claim
    {
        public int ClaimId { get; set; }

        public int ClaimantId { get; set; }

        public Claimant Claimant { get; set; }

        public DateTime DateOfLoss { get; set; }

        public string ClaimNumber { get; set; }

        public bool Deleted { get; set; }

        public bool IsNew()
        {
            return ClaimId == 0;
        }
    }
}
