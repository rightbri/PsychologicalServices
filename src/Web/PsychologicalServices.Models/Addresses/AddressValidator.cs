using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PsychologicalServices.Models.Addresses
{
    public class AddressValidator : IAddressValidator
    {
        private const string ProvincePattern = @"[A-Za-z]{2}";
        private const string PostalCodePatternCanada = @"([A-Za-z])([0-9])([A-Za-z])([0-9])([A-Za-z])([0-9])";
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
                    new ValidationError { Property = "Street", Message = "Street is required" }
                );
            }

            if (string.IsNullOrWhiteSpace(address.City))
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "City", Message = "City is required" }
                );
            }

            if (string.IsNullOrWhiteSpace(address.Province) || !Regex.IsMatch(address.Province, ProvincePattern))
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "Province", Message = "Province is required" }
                );
            }

            if (string.IsNullOrWhiteSpace(address.PostalCode))
            {

            }
            else
            {
                if (address.Country.Equals("Canada", StringComparison.OrdinalIgnoreCase) && !Regex.IsMatch(address.PostalCode, PostalCodePatternCanada))
                {
                    result.ValidationErrors.Add(
                        new ValidationError { Property = "PostalCode", Message = "Postal Code is not in a valid format" }
                    );
                }
                else if (address.Country.Equals("USA", StringComparison.OrdinalIgnoreCase) && !Regex.IsMatch(address.PostalCode, PostalCodePatternUsa))
                {
                    result.ValidationErrors.Add(
                        new ValidationError { Property = "PostalCode", Message = "Postal Code is not in a valid format" }
                    );
                }
            }
            
            if (string.IsNullOrWhiteSpace(address.Country))
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "Country", Message = "Country is required" }
                );
            }

            if (string.IsNullOrWhiteSpace(address.Name))
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "Name", Message = "Name is required" }
                );
            }

            var addressTypes = _addressRepository.GetAddressTypes();

            var addressType = addressTypes.SingleOrDefault(at => at.AddressTypeId == address.AddressTypeId);

            if (null == addressType)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "AddressTypeId", Message = "Invalid address type" }
                );
            }
            else if (!addressType.IsActive)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "AddressTypeId", Message = "The selected address type is not active." }
                );
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
