using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Companies
{
    public interface ICompanyService
    {
        Company GetCompany(int id);

        IEnumerable<Company> GetCompanies(bool? isActive = true);

        SaveResult<Company> SaveCompany(Company company);
    }
}
