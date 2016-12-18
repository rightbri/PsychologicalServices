using System;

namespace PsychologicalServices.Models.Referrals
{
    public class ReferralSourceSearchCriteria
    {
        public int? ReferralSourceId { get; set; }

        public string Name { get; set; }

        public int? ReferralSourceTypeId { get; set; }

        public bool? IsActive { get; set; }
    }
}
