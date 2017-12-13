using System;

namespace PsychologicalServices.Models.Claims
{
    public class ClaimantSearchParameters
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset? DateOfBirth { get; set; }
    }
}
