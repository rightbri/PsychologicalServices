using PsychologicalServices.Models.Cities;
using System;

namespace PsychologicalServices.Models.Addresses
{
    public class Address
    {
        public int AddressId { get; set; }

        public string Street { get; set; }

        public string Suite { get; set; }

        public City City { get; set;}

        public string PostalCode { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public AddressType AddressType { get; set; }

        public bool IsNew()
        {
            return AddressId == 0;
        }
    }
}
