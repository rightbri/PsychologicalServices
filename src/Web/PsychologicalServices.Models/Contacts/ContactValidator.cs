using PsychologicalServices.Models.Addresses;
using PsychologicalServices.Models.Common.Validation;
using PsychologicalServices.Models.Employers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Contacts
{
    public class ContactValidator : IContactValidator
    {
        private readonly IContactRepository _contactRepository = null;
        private readonly IEmployerRepository _employerRepository = null;
        private readonly IAddressRepository _addressRepository = null;

        public ContactValidator(
            IContactRepository contactRepository,
            IEmployerRepository employerRepository,
            IAddressRepository addressRepository
        )
        {
            _contactRepository = contactRepository;
            _employerRepository = employerRepository;
            _addressRepository = addressRepository;
        }

        public IValidationResult Validate(Contact item)
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

            if (null == item.ContactType)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "ContactTypeId", Message = "Contact type is required" }
                );
            }
            else
            {
                var contactType = _contactRepository.GetContactType(item.ContactType.ContactTypeId);
                if (null == contactType)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "ContactTypeId", Message = "Invalid contact type" }
                    );
                }
            }

            if (null != item.Employer)
            {
                var employer = _employerRepository.GetEmployer(item.Employer.EmployerId);
                if (null == employer)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "EmployerId", Message = "Invalid employer" }
                    );
                }
            }

            if (null != item.Address)
            {
                var address = _addressRepository.GetAddress(item.Address.AddressId);
                if (null == address)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "AddressId", Message = "Invalid address" }
                    );
                }
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
