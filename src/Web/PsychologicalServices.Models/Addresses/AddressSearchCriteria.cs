using System;

namespace PsychologicalServices.Models.Addresses
{
    public class AddressSearchCriteria
    {
        public string Street { get; set; }

        public string City { get; set; }

        public int? AddressTypeId { get; set; }
    }
}
