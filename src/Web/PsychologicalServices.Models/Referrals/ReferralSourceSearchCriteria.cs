using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Referrals
{
    public class ReferralSourceSearchCriteria
    {
        public int? ReferralSourceId { get; set; }

        public string Name { get; set; }

        public IEnumerable<int> ReferralSourceTypeIds { get; set; }

        public bool? IsActive { get; set; }
    }
}
