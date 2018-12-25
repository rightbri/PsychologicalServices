using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Claims
{
    public interface IClaimRepository
    {
        Claimant GetClaimant(int id);

        IssueInDispute GetIssueInDispute(int id);

        IEnumerable<ClaimReference> GetClaimReferences(int claimId);

        IEnumerable<Claimant> SearchClaimants(string name);

        IEnumerable<Claimant> SearchClaimants(ClaimantSearchParameters parameters);

        IEnumerable<IssueInDispute> GetReferralTypeIssuesInDispute(int referralTypeId);

        IEnumerable<IssueInDispute> GetIssuesInDispute(bool? isActive = true);

        IEnumerable<Gender> GetGenders();

        int SaveClaimant(Claimant claimant);

        int SaveIssueInDispute(IssueInDispute issueInDispute);

        bool DeleteClaimant(int id);
    }
}
