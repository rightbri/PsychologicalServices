using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Companies;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Companies
{
    public class CompanyRepository : RepositoryBase, ICompanyRepository
    {
        public CompanyRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        public Company GetCompany(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Company
                    .Where(company => company.CompanyId == id)
                    .SingleOrDefault()
                    .ToCompany();
            }
        }

        public IEnumerable<Company> GetCompanies(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<CompanyEntity>(
                        (ILLBLGenProQuery)
                        meta.Company
                        .Where(company => isActive == null || company.IsActive == isActive)
                    )
                    .Select(company => company.ToCompany())
                    .ToList();
            }
        }
        
        public int SaveCompany(Company company)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = company.IsNew();

                var entity = new CompanyEntity
                {
                    IsNew = isNew,
                    CompanyId = company.CompanyId
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                company.Name = company.Name;
                company.IsActive = company.IsActive;

                adapter.SaveEntity(entity);

                return entity.CompanyId;
            }
        }

    }
}
