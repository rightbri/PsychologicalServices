using System;

namespace PsychologicalServices.Models.Arbitrations
{
    public class ArbitrationSearchCriteria
    {
        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public int? CompanyId { get; set; }

        public int? ClaimantId { get; set; }
    }
}
