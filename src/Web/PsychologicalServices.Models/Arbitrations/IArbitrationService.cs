using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Arbitrations
{
    public interface IArbitrationService
    {
        Arbitration GetArbitration(int arbitrationId);

        IEnumerable<ArbitrationStatus> GetArbitrationStatuses(bool? isActive = true);

        IEnumerable<Arbitration> GetArbitrations(ArbitrationSearchCriteria criteria);

        SaveResult<Arbitration> SaveArbitration(Arbitration arbitration);
    }
}
