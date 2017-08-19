using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Arbitrations
{
    public interface IArbitrationRepository
    {
        IEnumerable<Arbitration> GetArbitrations(ArbitrationSearchCriteria criteria);
    }
}
