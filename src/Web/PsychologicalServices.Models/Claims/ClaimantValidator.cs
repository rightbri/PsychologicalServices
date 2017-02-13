using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Claims
{
    public class ClaimantValidator : IClaimantValidator
    {
        private readonly IClaimRepository _claimRepository = null;
        private readonly IClaimantParameters _claimantParameters = null;

        public ClaimantValidator(
            IClaimRepository claimRepository,
            IClaimantParameters claimantParameters
        )
        {
            _claimRepository = claimRepository;
            _claimantParameters = claimantParameters;
        }

        public IValidationResult Validate(Claimant item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (item.ClaimantId > 0)
            {
                var claimant = _claimRepository.GetClaimant(item.ClaimantId);

                if (null == claimant)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "ClaimantId", Message = "Invalid claimant" }
                    );
                }
            }

            if (string.IsNullOrWhiteSpace(item.FirstName))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "FirstName", Message = "Claimant first name is required" }
                );
            }

            if (string.IsNullOrWhiteSpace(item.LastName))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "LastName", Message = "Claimant last name is required" }
                );
            }

            if (!item.Age.HasValue && !item.DateOfBirth.HasValue)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "DateOfBirth", Message = "Claimant age or date of birth is required" }
                );
            }
            else
            {
                if (item.Age < _claimantParameters.MinAge)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "Age", Message = string.Format("Claimant age is below minimum value of {0}", _claimantParameters.MinAge) }
                    );
                }

                if (item.Age > _claimantParameters.MaxAge)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "Age", Message = string.Format("Claimant age is above maximum value of {0}", _claimantParameters.MaxAge) }
                    );
                }

            }
            
            if (!_claimantParameters.ValidGenders.Any(gender => gender.Abbreviation == item.Gender))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Gender", Message = string.Format("Claimant gender is not valid. Valid values include: {0}", string.Join(", ", _claimantParameters.ValidGenders.Select(gender => gender.Description))) }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
