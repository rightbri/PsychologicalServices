using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Claims
{
    public interface IClaimRepository
    {
        Claim GetClaim(int id);

        Claimant GetClaimant(int id);

        IssueInDispute GetIssueInDispute(int id);

        IEnumerable<Claim> GetAssessmentClaims(int assessmentId);

        IEnumerable<Claim> GetClaimsForClaimant(int claimantId);

        IEnumerable<Claimant> SearchClaimants(string name);

        IEnumerable<Claimant> SearchClaimants(ClaimantSearchParameters parameters);

        IEnumerable<IssueInDispute> GetReferralTypeIssuesInDispute(int referralTypeId);

        IEnumerable<IssueInDispute> GetIssuesInDispute(bool? isActive = true);

        IEnumerable<Gender> GetGenders();
        
        int SaveClaim(Claim claim);

        int SaveClaimant(Claimant claimant);

        int SaveIssueInDispute(IssueInDispute issueInDispute);

        bool DeleteClaimant(int id);
    }
}
