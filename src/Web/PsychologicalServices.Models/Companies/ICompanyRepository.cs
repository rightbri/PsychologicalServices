using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Companies
{
    public interface ICompanyRepository
    {
        Company GetCompany(int id);

        IEnumerable<Company> GetCompanies(bool? isActive = true);

        int SaveCompany(Company company);
    }
}
