using System;
using System.Collections.Generic;
using System.Linq;
using PsychologicalServices.Models.Common.Validation;
using PsychologicalServices.Models.Rights;

namespace PsychologicalServices.Models.Roles
{
    public class RoleValidator : IRoleValidator
    {
        private readonly IRightRepository _rightRepository = null;

        public RoleValidator(
            IRightRepository rightRepository
        )
        {
            _rightRepository = rightRepository;
        }

        public IValidationResult Validate(Role item)
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

            var rights = _rightRepository.GetRights(null);
            foreach (var roleRight in item.Rights)
            {
                var right = rights.SingleOrDefault(r => r.RightId == roleRight.RightId);
                if (null == right)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "RightId", Message = string.Format("Invalid right '{0}: {1}'", roleRight.RightId, roleRight.Name) }
                    );
                }
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
