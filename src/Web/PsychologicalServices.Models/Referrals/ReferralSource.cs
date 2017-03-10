using System;

namespace PsychologicalServices.Models.Referrals
{
    public class ReferralSource
    {
        public int ReferralSourceId { get; set; }

        public string Name { get; set; }

        public int ReferralSourceTypeId { get; set; }

        public ReferralSourceType ReferralSourceType { get; set; }

        public int LargeFileSize { get; set; }

        public int LargeFileFeeAmount { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return ReferralSourceId == 0;
        }
    }
}
