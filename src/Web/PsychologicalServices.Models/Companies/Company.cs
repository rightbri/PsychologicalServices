using System;

namespace PsychologicalServices.Models.Companies
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return CompanyId == 0;
        }
    }
}
