using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository = null;

        public CompanyService(
            ICompanyRepository companyRepository
        )
        {
            _companyRepository = companyRepository;
        }

        public Company GetCompany(int id)
        {
            var company = _companyRepository.GetCompany(id);

            if (null == company)
            {
                throw new CompanyNotFoundException(id);
            }

            return company;
        }

        public IEnumerable<Company> GetCompanies(bool? isActive = true)
        {
            var companies = _companyRepository.GetCompanies(isActive);

            return companies;
        }

        public SaveResult<Company> SaveCompany(Company company)
        {
            var result = new SaveResult<Company>();

            try
            {
                var id = _companyRepository.SaveCompany(company);

                result.Item = _companyRepository.GetCompany(id);
                result.IsSaved = true;
            }
            catch (Exception ex)
            {
                //TODO: log error
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
