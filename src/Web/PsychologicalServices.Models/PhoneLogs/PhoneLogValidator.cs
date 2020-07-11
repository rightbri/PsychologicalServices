using PsychologicalServices.Models.Common.Validation;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.PhoneLogs
{
    public class PhoneLogValidator : IPhoneLogValidator
    {
        private readonly IPhoneLogRepository _phoneLogRepository = null;
        private readonly IUserRepository _userRepository = null;

        public PhoneLogValidator(
            IPhoneLogRepository phoneLogRepository,
            IUserRepository userRepository
        )
        {
            _phoneLogRepository = phoneLogRepository;
            _userRepository = userRepository;
        }

        public IValidationResult Validate(PhoneLog item)
        {
            if (null == item)
            {
                throw new ArgumentNullException("item");
            }

            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (item.CallTime == DateTime.MinValue)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "CallTime", Message = GetValidationMessage(item, "Please select a call time") }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }

        private string GetValidationMessage(PhoneLog item, string message)
        {
            return string.Format("{0}{1}", GetMessagePrefix(item), message);
        }

        private string GetMessagePrefix(PhoneLog item)
        {
            return string.Format("Phone Log  {0:MMMM d, yyyy}: ", item.CallTime);
        }
    }
}
