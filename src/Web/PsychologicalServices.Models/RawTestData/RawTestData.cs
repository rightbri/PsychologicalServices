using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Notes;
using PsychologicalServices.Models.Referrals;
using PsychologicalServices.Models.Users;
using System;

namespace PsychologicalServices.Models.RawTestData
{
    public class RawTestData
    {
        public int RawTestDataId { get; set; }

        public Claimant Claimant { get; set; }

        public ReferralSource BillToReferralSource { get; set; }

        public User Psychologist { get; set; }

        public RawTestDataStatus Status { get; set; }

        public Company Company { get; set; }

        public Note Note { get; set; }

        public DateTimeOffset? RequestReceivedDate { get; set; }

        public DateTimeOffset? SignedAuthorizationReceivedDate { get; set; }

        public DateTimeOffset? DataSentDate { get; set; }

        public bool IsNew()
        {
            return RawTestDataId == 0;
        }
    }
}
