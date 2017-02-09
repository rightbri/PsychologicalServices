using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Claims
{
    public interface IClaimService
    {
        Claimant GetClaimant(int id);

        IEnumerable<Claim> GetAssessmentClaims(int assessmentId);

        IEnumerable<Claimant> SearchClaimants(string lastName);

        IEnumerable<IssueInDispute> GetReferralTypeIssuesInDispute(int referralTypeId);

        IEnumerable<IssueInDispute> GetIssuesInDispute(bool? isActive = true);

        SaveResult<Claimant> SaveClaimant(Claimant claimant);

        SaveResult<IssueInDispute> SaveIssueInDispute(IssueInDispute issueInDispute);
    }
}
