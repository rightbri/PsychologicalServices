using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Common.Validation;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Addresses
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository = null;
        private readonly IAddressValidator _addressValidator = null;

        public AddressService(
            IAddressRepository addressRepository,
            IAddressValidator addressValidator
        )
        {
            _addressRepository = addressRepository;
            _addressValidator = addressValidator;
        }

        public Address GetAddress(int id)
        {
            if (0 == id)
            {
                return new Address
                {
                    IsActive = true,
                };
            }

            var address = _addressRepository.GetAddress(id);

            if (null == address)
            {
                throw new AddressNotFoundException(id);
            }

            return address;
        }

        public IEnumerable<Address> SearchAddresses(AddressSearchCriteria criteria)
        {
            var addresses = _addressRepository.GetAddresses(criteria);

            return addresses;
        }

        public IEnumerable<AddressType> GetAddressTypes(bool? isActive = true)
        {
            var addressTypes = _addressRepository.GetAddressTypes(isActive);

            return addressTypes;
        }

        public SaveResult<Address> SaveAddress(Address address)
        {
            var result = new SaveResult<Address>();

            try
            {
                var validation = _addressValidator.Validate(address);

                result.ValidationResult = validation;
                
                if (result.ValidationResult.IsValid)
                {
                    var id = _addressRepository.SaveAddress(address);

                    result.Item = _addressRepository.GetAddress(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                //TODO: log error
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

    }
}
