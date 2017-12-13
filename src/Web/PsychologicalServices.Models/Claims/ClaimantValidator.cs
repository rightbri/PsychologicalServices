using PsychologicalServices.Models.Common.Utility;
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
        private readonly IDate _date = null;
        
        public ClaimantValidator(
            IClaimRepository claimRepository,
            IClaimantParameters claimantParameters,
            IDate date
        )
        {
            _claimRepository = claimRepository;
            _claimantParameters = claimantParameters;
            _date = date;
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
                        new ValidationError { PropertyName = "ClaimantId", Message = GetValidationMessage(item, "Invalid claimant") }
                    );
                }
            }
            else
            {
                //duplicate check
                var duplicates = _claimRepository.SearchClaimants(
                new ClaimantSearchParameters
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    DateOfBirth = item.DateOfBirth
                });

                if (duplicates.Any())
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "ClaimantId", Message = GetValidationMessage(item, $"A claimant already exists with the same name and date of birth") }
                    );
                }
            }

            if (string.IsNullOrWhiteSpace(item.FirstName))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "FirstName", Message = GetValidationMessage(item, "First name is required") }
                );
            }

            if (string.IsNullOrWhiteSpace(item.LastName))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "LastName", Message = GetValidationMessage(item, "Last name is required") }
                );
            }

            var age = _date.UtcNow.YearsFrom(item.DateOfBirth);

            if (age < _claimantParameters.MinAge)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "DateOfBirth", Message = GetValidationMessage(item, string.Format("Claimant cannot be younger than {0}", _claimantParameters.MinAge)) }
                );
            }
            else if (age > _claimantParameters.MaxAge)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "DateOfBirth", Message = GetValidationMessage(item, string.Format("Claimant cannot be older than {0}", _claimantParameters.MaxAge)) }
                );
            }
            
            if (!_claimantParameters.ValidGenders.Any(gender => gender.Abbreviation == item.Gender))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Gender", Message = GetValidationMessage(item, string.Format("Gender is not valid. Valid values include: {0}", string.Join(", ", _claimantParameters.ValidGenders.Select(gender => gender.Description)))) }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }

        private string GetValidationMessage(Claimant item, string message)
        {
            return string.Format("{0}{1}", GetMessagePrefix(item), message);
        }

        private string GetMessagePrefix(Claimant item)
        {
            return string.Format("Claimant {0} {1}: ", item.FirstName, item.LastName);
        }
    }
}
