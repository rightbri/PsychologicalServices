using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Claims
{
    public interface IClaimRepository
    {
        Claimant GetClaimant(int id);

        IssueInDispute GetIssueInDispute(int id);

        IEnumerable<Claim> GetAssessmentClaims(int assessmentId);

        IEnumerable<IssueInDispute> GetReferralTypeIssuesInDispute(int referralTypeId);

        IEnumerable<IssueInDispute> GetIssuesInDispute(bool? isActive = true);

        int SaveClaimant(Claimant claimant);

        int SaveIssueInDispute(IssueInDispute issueInDispute);
    }
}
