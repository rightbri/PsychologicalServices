using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Referrals
{
    public interface IReferralRepository
    {
        ReferralSource GetReferralSource(int id);

        ReferralSourceType GetReferralSourceType(int id);

        ReferralType GetReferralType(int id);

        IEnumerable<ReferralSource> GetReferralSources(ReferralSourceSearchCriteria criteria);

        IEnumerable<ReferralSourceType> GetReferralSourceTypes(bool? isActive = true);

        IEnumerable<ReferralType> GetReferralTypes(bool? isActive = true);

        int SaveReferralSource(ReferralSource referralSource);

        int SaveReferralSourceType(ReferralSourceType referralSourceType);

        int SaveReferralType(ReferralType referralType);
    }
}
