using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.DiagnosisFoundResponses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.DiagnosisFoundResponses
{
    public class DiagnosisFoundResponseRepository : RepositoryBase, IDiagnosisFoundResponseRepository
    {
        public DiagnosisFoundResponseRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        public IEnumerable<DiagnosisFoundResponse> GetDiagnosisFoundResponses(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<DiagnosisFoundResponseEntity>(
                    (ILLBLGenProQuery)
                    meta.DiagnosisFoundResponse
                    .Where(diagnosisFoundResponse => null == isActive || diagnosisFoundResponse.IsActive == isActive)
                )
                .Select(diagnosisFoundResponse => diagnosisFoundResponse.ToDiagnosisFoundResponse())
                .ToList();
            }
        }
    }
}
