using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Claims
{
    public class ClaimValidator : IClaimValidator
    {
        private readonly IClaimRepository _claimRepository = null;
        private readonly IDate _now = null;

        public ClaimValidator(
            IClaimRepository claimRepository,
            IDate now
        )
        {
            _claimRepository = claimRepository;
            _now = now;
        }

        public IValidationResult Validate(Claim item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            var claimant = _claimRepository.GetClaimant(item.Claimant.ClaimantId);

            if (null == claimant)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "ClaimantId", Message = "Invalid claimant" }
                );
            }

            if (item.DateOfLoss.HasValue &&
                item.DateOfLoss > _now.UtcNow)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "DateOfLoss", Message = "Date of loss cannot be in the future" }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
