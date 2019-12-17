using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Rights;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Rights
{
    public class RightRepository : RepositoryBase, IRightRepository
    {
        public RightRepository(
            IDataAccessAdapterFactory dataAccessAdapterFactory
        ) : base(dataAccessAdapterFactory)
        {
        }

        public IEnumerable<Right> GetRights(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<RightEntity>(
                        (ILLBLGenProQuery)
                        meta.Right
                        .Where(right => isActive == null || right.IsActive == isActive)
                    )
                    .Select(right => right.ToRight())
                    .ToList();
            }
        }
    }
}
