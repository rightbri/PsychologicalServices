using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Referrals
{
    public class ReferralTypeValidator : IReferralTypeValidator
    {
        private readonly IClaimRepository _claimRepository = null;

        public ReferralTypeValidator(
            IClaimRepository claimRepository
        )
        {
            _claimRepository = claimRepository;
        }

        public IValidationResult Validate(ReferralType item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "Name", Message = "Name is required" }
                );
            }

            var issuesInDispute = _claimRepository.GetIssuesInDispute(null);

            foreach (var issueInDispute in item.IssuesInDispute)
            {
                if (!issuesInDispute.Any(iid => iid.IssueInDisputeId == issueInDispute.IssueInDisputeId))
                {
                    result.ValidationErrors.Add(
                        new ValidationError { Property = "IssuesInDispute", Message = string.Format("Issue in dispute '{0}' is not valid", issueInDispute.Name) }
                    );
                }
            }
            
            result.IsValid = result.ValidationErrors.Any();

            return result;
        }
    }
}
