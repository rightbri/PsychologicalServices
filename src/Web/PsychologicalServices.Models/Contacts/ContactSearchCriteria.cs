using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Contacts
{
    public class ContactSearchCriteria
    {
        public int? ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public IEnumerable<int> ContactTypeIds { get; set; }

        public int? EmployerId { get; set; }

        public int? AddressId { get; set; }

        public bool? IsActive { get; set; }
    }
}
