using System;

namespace PsychologicalServices.Models.Claims
{
    public class ClaimantNotFoundException : Exception
    {
        private const string MessageFormat = "Claimant {0} was not found";

        public ClaimantNotFoundException(int claimantId)
            : base(string.Format(MessageFormat, claimantId))
        {
        }
    }
}
