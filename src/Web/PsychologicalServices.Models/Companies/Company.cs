using PsychologicalServices.Models.Addresses;
using System;

namespace PsychologicalServices.Models.Companies
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public Address Address { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string TaxId { get; set; }

        public bool IsNew()
        {
            return CompanyId == 0;
        }
    }
}
