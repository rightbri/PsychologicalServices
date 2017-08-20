using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Arbitrations;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Arbitrations
{
    public class ArbitrationRepository : RepositoryBase, IArbitrationRepository
    {
        public ArbitrationRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        #region Prefetch Paths

        private static readonly Func<IPathEdgeRootParser<ArbitrationEntity>, IPathEdgeRootParser<ArbitrationEntity>>
            ArbitrationPath =
                (arbitrationPath => arbitrationPath
                    .Prefetch<ContactEntity>(arbitration => arbitration.DefenseLawyer)
                        .SubPath(contactPath => contactPath
                            .Prefetch<ContactTypeEntity>(contact => contact.ContactType)
                            .Prefetch<EmployerEntity>(contact => contact.Employer)
                            .Prefetch<AddressEntity>(contact => contact.Address)
                                .SubPath(addressPath => addressPath
                                    .Prefetch<CityEntity>(address => address.City)
                                )
                        )
                );

        #endregion

        public IEnumerable<Arbitration> GetArbitrations(ArbitrationSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var arbitrations = meta.Arbitration
                    .Where(arbitration => arbitration.StartDate <= criteria.EndDate && arbitration.EndDate >= criteria.StartDate);

                if (criteria.CompanyId.HasValue)
                {
                    arbitrations = arbitrations.Where(arbitration => arbitration.Assessment.CompanyId == criteria.CompanyId);
                }
                
                return Execute<ArbitrationEntity>(
                        (ILLBLGenProQuery)
                        arbitrations
                    )
                    .Select(arbitration => arbitration.ToArbitration())
                    .ToList();
            }
        }
    }
}
