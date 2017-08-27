using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Outstanding
{
    public interface IOutstandingRepository
    {
        IEnumerable<OutstandingReport> GetOutstandingReports(OutstandingReportSearchCriteria criteria);

    }
}
