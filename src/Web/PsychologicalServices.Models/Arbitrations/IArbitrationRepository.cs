﻿using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Arbitrations
{
    public interface IArbitrationRepository
    {
        Arbitration GetArbitration(int arbitrationId);

        IEnumerable<Arbitration> GetArbitrations(ArbitrationSearchCriteria criteria);

        int SaveArbitration(Arbitration arbitration);
    }
}
