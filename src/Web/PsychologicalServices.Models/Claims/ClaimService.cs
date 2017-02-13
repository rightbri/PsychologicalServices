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

        public ClaimService(
            IClaimRepository claimRepository,
            IClaimValidator claimValidator,
            IClaimantValidator claimantValidator,
            IDate date
        )
        {
            _claimRepository = claimRepository;
            _claimValidator = claimValidator;
            _claimantValidator = claimantValidator;
            _date = date;
        }

        public Claimant GetClaimant(int id)
        {
            var claimant = _claimRepository.GetClaimant(id);

            if (null == claimant)
            {
                throw new ClaimantNotFoundException(id);
            }

            CalculateClaimantAge(claimant);

            return claimant;
        }

        public IEnumerable<Claim> GetAssessmentClaims(int assessmentId)
        {
            var claims = _claimRepository.GetAssessmentClaims(assessmentId);

            return claims;
        }

        public IEnumerable<Claimant> SearchClaimants(string lastName)
        {
            var claimants = _claimRepository.SearchClaimants(lastName);

            foreach (var claimant in claimants)
            {
                CalculateClaimantAge(claimant);
            }

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
                //TODO: log error
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
                CalculateClaimantAge(claimant);

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

        private void CalculateClaimantAge(Claimant claimant)
        {
            //recalculate age/date of birth
            if (claimant.DateOfBirth.HasValue)
            {
                claimant.Age = _date.Today.YearsFrom(claimant.DateOfBirth.Value);
            }
            else if (claimant.Age.HasValue)
            {
                //when calculating date of birth from age, always set claimant date of birth to 1/1/{birth year}
                claimant.DateOfBirth = new DateTime(_date.Today.AddYears(-claimant.Age.Value).Year, 1, 1);

            }
        }
    }
}
