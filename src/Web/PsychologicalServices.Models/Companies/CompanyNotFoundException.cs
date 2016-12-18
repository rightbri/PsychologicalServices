using System;

namespace PsychologicalServices.Models.Companies
{
    public class CompanyNotFoundException : Exception
    {
        private const string MessageFormat = "Company {0} was not found";

        public CompanyNotFoundException(int companyId)
            : base(string.Format(MessageFormat, companyId))
        {
        }
    }
}
