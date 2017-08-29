using System;
using PsychologicalServices.Models.Common.Validation;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Employers
{
    public class EmployerValidator : IEmployerValidator
    {
        private readonly IEmployerRepository _employerRepository = null;

        public EmployerValidator(
            IEmployerRepository employerRepository
        )
        {
            _employerRepository = employerRepository;
        }

        public IValidationResult Validate(Employer item)
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

            if (null == item.EmployerType)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "EmployerTypeId", Message = "Employer type is required" }
                );
            }
            else
            {
                var employerType = _employerRepository.GetEmployerType(item.EmployerType.EmployerTypeId);
                if (null == employerType)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "EmployerTypeId", Message = string.Format("Employer type '{0}' is not valid", item.EmployerType.EmployerTypeId) }
                    );
                }
            }
            
            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
