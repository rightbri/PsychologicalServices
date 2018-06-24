using System;
using System.Collections.Generic;
using System.Linq;
using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Common.Validation;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Referrals;
using PsychologicalServices.Models.Users;

namespace PsychologicalServices.Models.RawTestData
{
    public class RawTestDataValidator : IRawTestDataValidator
    {
        private readonly IClaimRepository _claimRepository = null;
        private readonly IReferralRepository _referralRepository = null;
        private readonly IRawTestDataRepository _rawTestDataRepository = null;
        private readonly IUserRepository _userRepository = null;
        private readonly ICompanyRepository _companyRepository = null;

        public RawTestDataValidator(
            IClaimRepository claimRepository,
            IReferralRepository referralRepository,
            IRawTestDataRepository rawTestDataRepository,
            IUserRepository userRepository,
            ICompanyRepository companyRepository
        )
        {
            _claimRepository = claimRepository;
            _referralRepository = referralRepository;
            _rawTestDataRepository = rawTestDataRepository;
            _userRepository = userRepository;
            _companyRepository = companyRepository;
        }

        public IValidationResult Validate(RawTestData item)
        {
            if (null == item)
            {
                throw new ArgumentNullException("item");
            }

            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (null != item.Claimant)
            {
                var claimant = _claimRepository.GetClaimant(item.Claimant.ClaimantId);

                if (null == claimant)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "Claimant", Message = "Invalid Claimant" }
                    );
                }
            }

            if (null != item.BillToReferralSource)
            {
                var referralSource = _referralRepository.GetReferralSource(item.BillToReferralSource.ReferralSourceId);

                if (null == referralSource)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "BillToReferralSource", Message = "Invalid Bill to Referral Source" }
                    );
                }
            }

            if (null != item.Psychologist)
            {
                var psychologist = _userRepository.GetUserById(item.Psychologist.UserId);

                if (null == psychologist)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "Psychologist", Message = "Invalid Psychologist" }
                    );
                }
                else if (!psychologist.Roles.Any(role => role.Rights.Any(right => right.RightId == (int)Rights.StaticRights.Psychologist)))
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "Psychologist", Message = "The user is not a psychologist" }
                    );
                }
            }

            if (null == item.Company)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Company", Message = "Company is required" }
                );
            }
            else
            {
                var company = _companyRepository.GetCompany(item.Company.CompanyId);

                if (null == company)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "Company", Message = "Invalid Company" }
                    );
                }
            }

            if (null != item.Status)
            {
                var statuses = _rawTestDataRepository.GetRawTestDataStatuses();

                if (!statuses.Any(status => status.RawTestDataStatusId == item.Status.RawTestDataStatusId))
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "Status", Message = "Invalid Raw Test Data Status" }
                    );
                }
            }

            if (!item.IsNew())
            {
                var rawTestData = _rawTestDataRepository.GetRawTestData(item.RawTestDataId);

                if (null == rawTestData)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "Item", Message = "Invalid Raw Test Data" }
                    );
                }
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
