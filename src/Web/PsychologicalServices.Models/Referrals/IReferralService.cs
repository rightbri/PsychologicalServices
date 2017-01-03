using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Referrals
{
    public interface IReferralService
    {
        ReferralSource GetReferralSource(int id);

        ReferralSourceType GetReferralSourceType(int id);

        ReferralType GetReferralType(int id);

        IEnumerable<ReferralSource> GetReferralSources(ReferralSourceSearchCriteria criteria);

        IEnumerable<ReferralSourceType> GetReferralSourceTypes(bool? isActive = true);

        IEnumerable<ReferralType> GetReferralTypes(bool? isActive = true);

        SaveResult<ReferralSource> SaveReferralSource(ReferralSource referralSource);

        SaveResult<ReferralSourceType> SaveReferralSourceType(ReferralSourceType referralSourceType);

        SaveResult<ReferralType> SaveReferralType(ReferralType referralType);
    }
}
