using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.RawTestData
{
    public class RawTestDataSearchCriteria
    {
        public int? CompanyId { get; set; }

        public int? ClaimantId { get; set; }

        public string RecipientName { get; set; }

        public IEnumerable<int> RawTestDataStatusIds { get; set; }
    }
}
