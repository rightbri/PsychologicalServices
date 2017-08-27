using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Outstanding
{
    public interface IOutstandingService
    {
        IEnumerable<OutstandingReport> GetOutstandingReports(OutstandingReportSearchCriteria criteria);
    }
}
