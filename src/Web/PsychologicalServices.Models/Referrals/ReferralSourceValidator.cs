using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Referrals
{
    public class ReferralSourceValidator : IReferralSourceValidator
    {
        private readonly IReferralRepository _referralRepository = null;

        public ReferralSourceValidator(
            IReferralRepository referralRepository
        )
        {
            _referralRepository = referralRepository;
        }

        public IValidationResult Validate(ReferralSource item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Name", Message = "Name is required" }
                );
            }

            var referralSourceTypes = _referralRepository.GetReferralSourceTypes(null);

            if (!referralSourceTypes.Any(rst => rst.ReferralSourceTypeId == item.ReferralSourceType.ReferralSourceTypeId))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "ReferralSourceTypeId", Message = string.Format("Referral source type '{0}' is not valid", item.ReferralSourceType.ReferralSourceTypeId) }
                );
            }

            //if (item.LargeFileSize <= 0)
            //{
            //    result.ValidationErrors.Add(
            //        new ValidationError { PropertyName = "LargeFileSize", Message = "Large file size must be greater than zero" }
            //    );
            //}

            //if (item.LargeFileFeeAmount < 0)
            //{
            //    result.ValidationErrors.Add(
            //        new ValidationError { PropertyName = "LargeFileFeeAmount", Message = "Large file fee amount must be greater than or equal to zero" }
            //    );
            //}

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
