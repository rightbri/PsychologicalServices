using PsychologicalServices.Data.DatabaseSpecific;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Outstanding;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Outstanding
{
    public class OutstandingRepository : RepositoryBase, IOutstandingRepository
    {
        public OutstandingRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        public IEnumerable<OutstandingReport> GetOutstandingReports(OutstandingReportSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var table = RetrievalProcedures.OutstandingReports(criteria.CompanyId, criteria.DaysOutstanding, criteria.SearchStart, (DataAccessAdapter)adapter);

                return table
                    .AsEnumerable()
                    .Select(row =>
                        new OutstandingReport
                        {
                            AssessmentId = Convert.ToInt32(row["AssessmentId"]),
                            AppointmentTime = (DateTimeOffset)row["AppointmentTime"],
                            Claimant = Convert.ToString(row["Claimant"]),
                            ReferralSource = Convert.ToString(row["ReferralSource"]),
                        })
                    .ToList();
            }
        }
    }
}
