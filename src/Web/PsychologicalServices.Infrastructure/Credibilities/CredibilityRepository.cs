using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Credibilities;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Credibilities
{
    public class CredibilityRepository : RepositoryBase, ICredibilityRepository
    {
        public CredibilityRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        public IEnumerable<Credibility> GetCredibilities(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<CredibilityEntity>(
                    (ILLBLGenProQuery)
                        meta.Credibility
                        .Where(credibility => isActive == null || credibility.IsActive == isActive)
                    )
                    .Select(credibility => credibility.ToCredibility())
                    .ToList();
            }
        }
    }
}
