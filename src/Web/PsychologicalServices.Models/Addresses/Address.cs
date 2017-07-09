using PsychologicalServices.Models.Cities;
using System;
using System.Collections.Generic;

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

        public IEnumerable<AddressType> AddressTypes { get; set; }

        public bool IsNew()
        {
            return AddressId == 0;
        }
    }
}
