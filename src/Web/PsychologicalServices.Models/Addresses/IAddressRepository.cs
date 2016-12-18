using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Addresses
{
    public interface IAddressRepository
    {
        Address GetAddress(int id);

        AddressType GetAddressType(int id);

        IEnumerable<Address> GetAddresses(AddressSearchCriteria criteria);

        IEnumerable<AddressType> GetAddressTypes(bool? isActive = true);

        int SaveAddress(Address address);

        int SaveAddressType(AddressType addressType);
    }
}
