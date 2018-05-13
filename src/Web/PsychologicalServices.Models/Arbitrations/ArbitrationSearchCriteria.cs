using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Arbitrations
{
    public class ArbitrationSearchCriteria
    {
        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public int? CompanyId { get; set; }

        public int? ClaimantId { get; set; }

        public IEnumerable<int> ArbitrationStatusIds { get; set; }
    }
}
