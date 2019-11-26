using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Referrals;
using PsychologicalServices.Models.Users;
using System;

namespace PsychologicalServices.Models.Consulting
{
    public class ConsultingAgreement
    {
        public int ConsultingAgreementId { get; set; }

        public User Psychologist { get; set; }

        public ReferralSource BillToReferralSource { get; set; }

        public Company Company { get; set; }
    }
}
