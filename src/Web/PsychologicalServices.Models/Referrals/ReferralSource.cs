using PsychologicalServices.Models.Addresses;

namespace PsychologicalServices.Models.Referrals
{
    public class ReferralSource
    {
        public int ReferralSourceId { get; set; }

        public string Name { get; set; }

        public string InvoicesContactEmail { get; set; }

        public ReferralSourceType ReferralSourceType { get; set; }

        public bool IsActive { get; set; }

        public Address Address { get; set; }

        public bool IsNew()
        {
            return ReferralSourceId == 0;
        }
    }
}
