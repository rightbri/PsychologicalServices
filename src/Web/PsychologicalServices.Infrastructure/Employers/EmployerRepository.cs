using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Employers;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Employers
{
    public class EmployerRepository : RepositoryBase, IEmployerRepository
    {
        public EmployerRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<EmployerEntity>, IPathEdgeRootParser<EmployerEntity>>
            EmployerPath =
                (employerPath => employerPath
                    .Prefetch<EmployerTypeEntity>(employer => employer.EmployerType)
                );

        #endregion

        public Employer GetEmployer(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Employer
                    .WithPath(EmployerPath)
                    .Where(employer => employer.EmployerId == id)
                    .SingleOrDefault()
                    .ToEmployer();
            }
        }

        public EmployerType GetEmployerType(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.EmployerType
                    .Where(employerType => employerType.EmployerTypeId == id)
                    .SingleOrDefault()
                    .ToEmployerType();
            }
        }

        public IEnumerable<Employer> GetEmployers(EmployerSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var employers = meta.Employer
                    .WithPath(EmployerPath);

                if (null != criteria)
                {
                    if (criteria.EmployerId.HasValue)
                    {
                        employers = employers.Where(employer => employer.EmployerId == criteria.EmployerId.Value);
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.Name))
                    {
                        employers = employers.Where(employer => employer.Name.Contains(criteria.Name));
                    }

                    if (null != criteria.EmployerTypeIds && criteria.EmployerTypeIds.Any())
                    {
                        employers = employers.Where(emmployer =>
                            criteria.EmployerTypeIds.Contains(emmployer.EmployerTypeId)
                        );
                    }

                    if (criteria.IsActive.HasValue)
                    {
                        employers = employers.Where(employer => employer.IsActive == criteria.IsActive);
                    }
                }

                return Execute<EmployerEntity>(
                        (ILLBLGenProQuery)
                        employers
                    )
                    .Select(employer => employer.ToEmployer())
                    .ToList();
            }
        }

        public IEnumerable<EmployerType> GetEmployerTypes(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<EmployerTypeEntity>(
                        (ILLBLGenProQuery)
                        meta.EmployerType
                        .Where(employerType => isActive == null || employerType.IsActive == isActive)
                    )
                    .Select(employerType => employerType.ToEmployerType())
                    .ToList();
            }
        }

        public int SaveEmployer(Employer employer)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = employer.IsNew();

                var entity = new EmployerEntity
                {
                    IsNew = isNew,
                    EmployerId = employer.EmployerId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.Name = employer.Name;
                entity.IsActive = employer.IsActive;
                entity.EmployerTypeId = employer.EmployerType.EmployerTypeId;
                
                adapter.SaveEntity(entity);

                return entity.EmployerId;
            }
        }

        public int SaveEmployerType(EmployerType employerType)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = employerType.IsNew();

                var entity = new EmployerTypeEntity
                {
                    IsNew = isNew,
                    EmployerTypeId = employerType.EmployerTypeId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.Name = employerType.Name;
                entity.IsActive = employerType.IsActive;

                adapter.SaveEntity(entity);

                return entity.EmployerTypeId;
            }
        }
    }
}
