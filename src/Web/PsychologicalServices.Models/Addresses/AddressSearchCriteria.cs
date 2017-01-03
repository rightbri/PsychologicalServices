using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Addresses
{
    public class AddressSearchCriteria
    {
        public string Name { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public IEnumerable<int> AddressTypeIds { get; set; }

        public bool? IsActive { get; set; }

        public string SearchTerm { get; set; }
    }
}
