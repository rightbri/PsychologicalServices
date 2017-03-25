using PsychologicalServices.Models.Common.Validation;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Users
{
    public class UserValidator : IUserValidator
    {
        private readonly ICompanyRepository _companyRepository = null;
        private readonly IRoleRepository _roleRepository = null;
        private readonly IUnavailabilityValidator _unavailabilityValidator = null;
        private readonly IUserTravelFeeValidator _userTravelFeeValidator = null;

        public UserValidator(
            ICompanyRepository companyRepository,
            IRoleRepository roleRepository,
            IUnavailabilityValidator unavailabilityValidator,
            IUserTravelFeeValidator userTravelFeeValidator
        )
        {
            _companyRepository = companyRepository;
            _roleRepository = roleRepository;
            _unavailabilityValidator = unavailabilityValidator;
            _userTravelFeeValidator = userTravelFeeValidator;
        }

        public IValidationResult Validate(User item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (string.IsNullOrWhiteSpace(item.FirstName))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "FirstName", Message = "First name is required" }
                );
            }

            if (string.IsNullOrWhiteSpace(item.LastName))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "LastName", Message = "Last name is required" }
                );
            }

            if (string.IsNullOrWhiteSpace(item.Email))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Email", Message = "Email is required" }
                );
            }

            var company = _companyRepository.GetCompany(item.Company.CompanyId);
            if (null == company)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "CompanyId", Message = "Invalid company" }
                );
            }

            var roles = _roleRepository.GetRoles(null);
            foreach (var userRole in item.Roles)
            {
                var role = roles.SingleOrDefault(r => r.RoleId == userRole.RoleId);
                if (null == role)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "RoleId", Message = string.Format("Invalid role '{0}: {1}'", userRole.RoleId, userRole.Name) }
                    );
                }
            }

            if (null != item.Unavailability)
            {
                foreach (var unavailability in item.Unavailability)
                {
                    result.ValidationErrors.AddRange(
                        _unavailabilityValidator.Validate(unavailability).ValidationErrors
                    );
                }
            }

            if (null != item.TravelFees)
            {
                foreach (var travelFee in item.TravelFees)
                {
                    result.ValidationErrors.AddRange(
                        _userTravelFeeValidator.Validate(travelFee).ValidationErrors
                    );
                }
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
