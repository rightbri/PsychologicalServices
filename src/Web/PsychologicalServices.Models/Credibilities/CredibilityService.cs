using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Credibilities
{
    public class CredibilityService : ICredibilityService
    {
        private readonly ICredibilityRepository _credibilityRepository = null;

        public CredibilityService(
            ICredibilityRepository credibilityRepository
        )
        {
            _credibilityRepository = credibilityRepository;
        }

        public IEnumerable<Credibility> GetCredibilities(bool? isActive = true)
        {
            var credibilities = _credibilityRepository.GetCredibilities(isActive);

            return credibilities;
        }
    }
}
