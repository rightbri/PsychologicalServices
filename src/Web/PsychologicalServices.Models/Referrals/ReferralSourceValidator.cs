using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Referrals
{
    public class ReferralSourceValidator : IReferralSourceValidator
    {
        private readonly IReferralRepository _referralRepository = null;
        private readonly IEmailAddressValidator _emailAddressValidator = null;

        public ReferralSourceValidator(
            IReferralRepository referralRepository,
            IEmailAddressValidator emailAddressValidtor
        )
        {
            _referralRepository = referralRepository;
            _emailAddressValidator = emailAddressValidtor;
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
                    new ValidationError { PropertyName = "ReferralSourceTypeId", Message = $"Referral source type '{item.ReferralSourceType.ReferralSourceTypeId}' is not valid" }
                );
            }

            if (!string.IsNullOrEmpty(item.InvoicesContactEmail) &&
                !_emailAddressValidator.IsValid(item.InvoicesContactEmail))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "InvoicesContactEmail", Message = $"{item.InvoicesContactEmail} is not a valid invoices contact email", }
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
