using System;

namespace PsychologicalServices.Models.Outstanding
{
    public class OutstandingReportSearchCriteria
    {
        public int CompanyId { get; set; }

        public int? DaysOutstanding { get; set; }

        public DateTimeOffset? SearchStart { get; set; }
    }
}
