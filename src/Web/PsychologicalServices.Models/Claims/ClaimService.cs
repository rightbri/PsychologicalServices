using log4net;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Claims
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepository = null;
        private readonly IClaimValidator _claimValidator = null;
        private readonly IClaimantValidator _claimantValidator = null;
        private readonly IDate _date = null;
        private readonly ILog _log = null;

        public ClaimService(
            IClaimRepository claimRepository,
            IClaimValidator claimValidator,
            IClaimantValidator claimantValidator,
            IDate date,
            ILog log
        )
        {
            _claimRepository = claimRepository;
            _claimValidator = claimValidator;
            _claimantValidator = claimantValidator;
            _date = date;
            _log = log;
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

        public IEnumerable<Claim> GetClaimsForClaimant(int claimantId)
        {
            var claims = _claimRepository.GetClaimsForClaimant(claimantId);

            return claims;
        }

        public IEnumerable<Claimant> SearchClaimants(string name)
        {
            var claimants = _claimRepository.SearchClaimants(name);
            
            return claimants;
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

        public IEnumerable<Gender> GetGenders()
        {
            var genders = _claimRepository.GetGenders();

            return genders;
        }

        public SaveResult<Claim> SaveClaim(Claim claim)
        {
            var result = new SaveResult<Claim>();

            try
            {
                var validation = _claimValidator.Validate(claim);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _claimRepository.SaveClaim(claim);

                    result.Item = _claimRepository.GetClaim(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveClaim", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public SaveResult<Claimant> SaveClaimant(Claimant claimant)
        {
            var result = new SaveResult<Claimant>();

            try
            {
                var validation = _claimantValidator.Validate(claimant);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _claimRepository.SaveClaimant(claimant);

                    result.Item = _claimRepository.GetClaimant(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveClaimant", ex);
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
                _log.Error("SaveIssueInDispute", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
        
        public DeleteResult DeleteClaimant(int id)
        {
            var result = new DeleteResult();

            try
            {
                result.IsDeleted = _claimRepository.DeleteClaimant(id);
            }
            catch (Exception ex)
            {
                _log.Error("DeleteClaimant", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
