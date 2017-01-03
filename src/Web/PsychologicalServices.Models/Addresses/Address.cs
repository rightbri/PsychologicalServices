using System;

namespace PsychologicalServices.Models.Addresses
{
    public class Address
    {
        public int AddressId { get; set; }

        public string Street { get; set; }

        public string Suite { get; set; }

        public string City { get; set;}

        public string Province { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public int AddressTypeId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public AddressType AddressType { get; set; }

        public bool IsNew()
        {
            return AddressId == 0;
        }
    }
}
