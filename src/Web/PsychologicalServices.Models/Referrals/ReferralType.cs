using PsychologicalServices.Models.Claims;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Referrals
{
    public class ReferralType
    {
        public int ReferralTypeId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<IssueInDispute> IssuesInDispute { get; set; }

        public bool IsNew()
        {
            return ReferralTypeId == 0;
        }
    }
}
