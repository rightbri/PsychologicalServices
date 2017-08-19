using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Arbitrations
{
    public interface IArbitrationService
    {
        Arbitration GetNewArbitration(int assessmentId);

        IEnumerable<Arbitration> GetArbitrations(ArbitrationSearchCriteria criteria);
    }
}
