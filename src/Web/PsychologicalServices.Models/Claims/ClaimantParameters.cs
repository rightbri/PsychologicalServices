using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Claims
{
    public class ClaimantParameters : IClaimantParameters
    {
        private readonly IClaimRepository _claimRepository = null;

        public ClaimantParameters(
            IClaimRepository claimRepository
        )
        {
            _claimRepository = claimRepository;
        }

        //TODO: pull from database or config
        public int MinAge
        {
            get
            {
                return 18;
            }
        }

        //TODO: pull from database or config
        public int MaxAge
        {
            get
            {
                return 70;
            }
        }

        public IEnumerable<Gender> ValidGenders
        {
            get
            {
                return _claimRepository.GetGenders();
            }
        }
    }
}
