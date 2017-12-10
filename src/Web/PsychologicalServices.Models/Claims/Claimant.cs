using System;

namespace PsychologicalServices.Models.Claims
{
    public class Claimant
    {
        public int ClaimantId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public string Gender { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return ClaimantId == 0;
        }

        public int Age
        {
            get
            {
                var now = DateTimeOffset.UtcNow;

                var age = now.Year - DateOfBirth.Year;

                var monthDifference = now.Month - DateOfBirth.Month;

                if (monthDifference < 0 ||
                    (monthDifference == 0 && now.Day < DateOfBirth.Day) ||
                    (monthDifference == 0 && now.Day == DateOfBirth.Day && now.Hour < DateOfBirth.Hour))
                {
                    age--;
                }

                return age;
            }
        }
    }
}
