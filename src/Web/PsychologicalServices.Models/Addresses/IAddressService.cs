using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Addresses
{
    public interface IAddressService
    {
        Address GetAddress(int id);

        IEnumerable<Address> SearchAddresses(AddressSearchCriteria criteria);

        IEnumerable<AddressType> GetAddressTypes(bool? isActive = true);

        SaveResult<Address> SaveAddress(Address address);
    }
}
