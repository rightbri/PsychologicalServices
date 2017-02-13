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

        IEnumerable<Claimant> SearchClaimants(string lastName);

        IEnumerable<IssueInDispute> GetReferralTypeIssuesInDispute(int referralTypeId);

        IEnumerable<IssueInDispute> GetIssuesInDispute(bool? isActive = true);

        IEnumerable<Gender> GetGenders();
        
        int SaveClaim(Claim claim);

        int SaveClaimant(Claimant claimant);

        int SaveIssueInDispute(IssueInDispute issueInDispute);
    }
}
