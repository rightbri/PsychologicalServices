using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Claims
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepository = null;

        public ClaimService(
            IClaimRepository claimRepository
        )
        {
            _claimRepository = claimRepository;
        }

        public Claimant GetClaimant(int id)
        {
            var claimant = _claimRepository.GetClaimant(id);

            if (null == claimant)
            {
                throw new ClaimantNotFoundException(id);
            }

            return claimant;
        }

        public IEnumerable<Claim> GetAssessmentClaims(int assessmentId)
        {
            var claims = _claimRepository.GetAssessmentClaims(assessmentId);

            return claims;
        }

        public IEnumerable<IssueInDispute> GetReferralTypeIssuesInDispute(int referralTypeId)
        {
            var issuesInDispute = _claimRepository.GetReferralTypeIssuesInDispute(referralTypeId);

            return issuesInDispute;
        }

        public IEnumerable<IssueInDispute> GetIssuesInDispute(bool? isActive = true)
        {
            var issuesInDispute = _claimRepository.GetIssuesInDispute(isActive);

            return issuesInDispute;
        }

        public SaveResult<Claimant> SaveClaimant(Claimant claimant)
        {
            var result = new SaveResult<Claimant>();

            try
            {
                var id = _claimRepository.SaveClaimant(claimant);

                result.Item = _claimRepository.GetClaimant(id);
                result.IsSaved = true;
            }
            catch (Exception ex)
            {
                //TODO: log error
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public SaveResult<IssueInDispute> SaveIssueInDispute(IssueInDispute issueInDispute)
        {
            var result = new SaveResult<IssueInDispute>();

            try
            {
                var id = _claimRepository.SaveIssueInDispute(issueInDispute);

                result.Item = _claimRepository.GetIssueInDispute(id);
                result.IsSaved = true;
            }
            catch (Exception ex)
            {
                //TODO: log error
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
