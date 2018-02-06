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
                    .Prefetch<ClaimantEntity>(arbitration => arbitration.Claimant)
                    .Prefetch<ContactEntity>(arbitration => arbitration.DefenseLawyer)
                        .SubPath(contactPath => contactPath
                            .Prefetch<ContactTypeEntity>(contact => contact.ContactType)
                            .Prefetch<EmployerEntity>(contact => contact.Employer)
                            .Prefetch<AddressEntity>(contact => contact.Address)
                                .SubPath(addressPath => addressPath
                                    .Prefetch<CityEntity>(address => address.City)
                                )
                        )
                    .Prefetch<ContactEntity>(arbitration => arbitration.PlaintiffLawyer)
                        .SubPath(contactPath => contactPath
                            .Prefetch<ContactTypeEntity>(contact => contact.ContactType)
                            .Prefetch<EmployerEntity>(contact => contact.Employer)
                            .Prefetch<AddressEntity>(contact => contact.Address)
                                .SubPath(addressPath => addressPath
                                    .Prefetch<CityEntity>(address => address.City)
                                )
                        )
                    .Prefetch<NoteEntity>(arbitration => arbitration.Note)
                        .SubPath(notePath => notePath
                            .Prefetch<UserEntity>(note => note.CreateUser)
                            .Prefetch<UserEntity>(note => note.UpdateUser)
                        )
                );

        #endregion

        public Arbitration GetArbitration(int arbitrationId)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var arbitration = meta.Arbitration
                    .WithPath(ArbitrationPath)
                    .Where(a => a.ArbitrationId == arbitrationId)
                    .SingleOrDefault()
                    .ToArbitration();

                return arbitration;
            }
        }

        public IEnumerable<Arbitration> GetArbitrations(ArbitrationSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var arbitrations = meta.Arbitration
                    .WithPath(ArbitrationPath)
                    .Where(arbitration =>
                        arbitration.StartDate <= criteria.EndDate &&
                        (arbitration.EndDate == null || arbitration.EndDate >= criteria.StartDate)
                    );

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
