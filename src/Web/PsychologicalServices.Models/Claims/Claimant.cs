using System;

namespace PsychologicalServices.Models.Claims
{
    public class Claimant
    {
        public int ClaimantId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? Age { get; set; }

        public string Gender { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return ClaimantId == 0;
        }
    }
}
