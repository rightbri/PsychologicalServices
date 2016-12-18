using System;

namespace PsychologicalServices.Models.Referrals
{
    public class ReferralSourceType
    {
        public int ReferralSourceTypeId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return ReferralSourceTypeId == 0;
        }
    }
}
