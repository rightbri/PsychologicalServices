using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Rights
{
    public class RightService : IRightService
    {
        private readonly IRightRepository _rightRepository = null;

        public RightService(
            IRightRepository rightRepository
        )
        {
            _rightRepository = rightRepository;
        }

        public IEnumerable<Right> GetRights(bool? isActive = true)
        {
            var rights = _rightRepository.GetRights(isActive);

            return rights;
        }
    }
}
