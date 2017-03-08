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

        public UserValidator(
            ICompanyRepository companyRepository,
            IRoleRepository roleRepository
        )
        {
            _companyRepository = companyRepository;
            _roleRepository = roleRepository;
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

            var company = _companyRepository.GetCompany(item.CompanyId);
            if (null == company)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "CompanyId", Message = "Invalid company" }
                );
            }

            var roles = _roleRepository.GetRoles(false);
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

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
