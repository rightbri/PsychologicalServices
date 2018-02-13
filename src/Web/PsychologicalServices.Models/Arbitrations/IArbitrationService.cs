using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Arbitrations
{
    public interface IArbitrationService
    {
        Arbitration GetArbitration(int arbitrationId);

        Arbitration GetNewArbitration(int assessmentId);

        IEnumerable<Arbitration> GetArbitrations(ArbitrationSearchCriteria criteria);

        SaveResult<Arbitration> SaveArbitration(Arbitration arbitration);
    }
}
