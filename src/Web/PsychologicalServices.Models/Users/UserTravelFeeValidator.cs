using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Users
{
    public class UserTravelFeeValidator : IUserTravelFeeValidator
    {
        public IValidationResult Validate(UserTravelFee item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (null == item.City)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "City", Message = "City is required" }
                );
            }

            if (item.Amount < 0)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Amount", Message = "Amount must be greater than or equal to zero" }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
