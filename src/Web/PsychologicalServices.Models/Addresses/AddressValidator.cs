using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PsychologicalServices.Models.Addresses
{
    public class AddressValidator : IAddressValidator
    {
        private const string PostalCodePatternCanada = @"([A-Za-z])([0-9])([A-Za-z])[ ]?([0-9])([A-Za-z])([0-9])";
        private const string PostalCodePatternUsa = @"([0-9]){5}";

        private readonly IAddressRepository _addressRepository = null;

        public AddressValidator(
            IAddressRepository addressRepository
        )
        {
            _addressRepository = addressRepository;
        }

        public IValidationResult Validate(Address address)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (string.IsNullOrWhiteSpace(address.Street))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Street", Message = "Street is required" }
                );
            }

            if (null == address.City)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "City", Message = "City is required" }
                );
            }

            if (string.IsNullOrWhiteSpace(address.PostalCode))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "PostalCode", Message = "Postal Code is required" }
                );
            }
            else
            {
                if (null != address.City.Country)
                {
                    if (address.City.Country.Equals("Canada", StringComparison.OrdinalIgnoreCase) && !Regex.IsMatch(address.PostalCode, PostalCodePatternCanada))
                    {
                        result.ValidationErrors.Add(
                            new ValidationError { PropertyName = "PostalCode", Message = "Postal Code is not in a valid format" }
                        );
                    }
                    else if (address.City.Country.Equals("USA", StringComparison.OrdinalIgnoreCase) && !Regex.IsMatch(address.PostalCode, PostalCodePatternUsa))
                    {
                        result.ValidationErrors.Add(
                            new ValidationError { PropertyName = "PostalCode", Message = "Postal Code is not in a valid format" }
                        );
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(address.Name))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Name", Message = "Name is required" }
                );
            }

            var addressTypes = _addressRepository.GetAddressTypes();

            var invalidAddressTypes =
                null != address.AddressTypes
                ? address.AddressTypes
                    .Where(addressType => !addressTypes.Any(at => at.AddressTypeId == addressType.AddressTypeId))
                : Enumerable.Empty<AddressType>();

            result.ValidationErrors.AddRange(
                invalidAddressTypes.Select(addressType => new ValidationError
                {
                    PropertyName = "AddressTypeId",
                    Message = $"Invalid address type: {addressType.Name}"
                })
            );
            
            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
