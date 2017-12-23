using PsychologicalServices.Data.DatabaseSpecific;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Analysis;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Assessments;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Analysis
{
    public class AnalysisRepository : RepositoryBase, IAnalysisRepository
    {
        public AnalysisRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        public IEnumerable<BookingData> GetBookingData(BookingDataSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var table = RetrievalProcedures.BookingData(criteria.CompanyId, criteria.Months, (DataAccessAdapter)adapter);

                return table
                    .AsEnumerable()
                    .Select(row =>
                        new BookingData
                        {
                            AssessmentId = Convert.ToInt32(row["AssessmentId"]),
                            ReferralSourceId = Convert.ToInt32(row["ReferralSourceId"]),
                            ReferralSource = Convert.ToString(row["ReferralSource"]),
                            Year = Convert.ToInt32(row["Year"]),
                            Month = Convert.ToInt32(row["Month"]),
                            IsPsychological = Convert.ToBoolean(row["IsPsychological"]),
                            IsLargeFile = Convert.ToBoolean(row["IsLargeFile"]),
                        })
                    .ToList();
            }
        }

        public IEnumerable<CancellationData> GetCancellationData(CancellationDataSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var table = RetrievalProcedures.CancellationData(criteria.CompanyId, criteria.Months, (DataAccessAdapter) adapter);

                return table
                    .AsEnumerable()
                    .Select(row =>
                        new CancellationData
                        {
                            AssessmentId = Convert.ToInt32(row["AssessmentId"]),
                            ReferralSourceId = Convert.ToInt32(row["ReferralSourceId"]),
                            ReferralSource = Convert.ToString(row["ReferralSource"]),
                            Year = Convert.ToInt32(row["Year"]),
                            Month = Convert.ToInt32(row["Month"]),
                            AppointmentCount = Convert.ToInt32(row["AppointmentCount"]),
                            BillableCount = Convert.ToInt32(row["BillableCount"]),
                            CanceledCount = Convert.ToInt32(row["CanceledCount"]),
                            LateCanceledCount = Convert.ToInt32(row["LateCanceledCount"]),
                        })
                    .ToList();
            }
        }

        public IEnumerable<CompletionData> GetCompletionData(CompletionDataSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var table = RetrievalProcedures.CompletionData(criteria.CompanyId, criteria.Months, (DataAccessAdapter)adapter);

                return table
                    .AsEnumerable()
                    .Select(row =>
                        new CompletionData
                        {
                            AssessmentId = Convert.ToInt32(row["AssessmentId"]),
                            AppointmentTime = (DateTimeOffset) row["AppointmentTime"],
                            Year = Convert.ToInt32(row["Year"]),
                            Month = Convert.ToInt32(row["Month"]),
                            Psychometrist = Convert.ToString(row["Psychometrist"]),
                            IncompleteCount = Convert.ToInt32(row["IncompleteCount"]),
                            CompleteCount = Convert.ToInt32(row["CompleteCount"]),
                            HasTranslator = Convert.ToBoolean(row["HasTranslator"]),
                            HasReader = Convert.ToBoolean(row["HasReader"]),
                            HasPsychiatrist = Convert.ToBoolean(row["HasPsychiatrist"]),
                            IsFemaleClaimant = Convert.ToBoolean(row["IsFemaleClaimant"]),
                        })
                    .ToList();
            }
        }
        
        public IEnumerable<ArbitrationData> GetArbitrationData(ArbitrationDataSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var table = RetrievalProcedures.ArbitrationsData(criteria.CompanyId, criteria.Months, (DataAccessAdapter)adapter);

                return table
                    .AsEnumerable()
                    .Select(row =>
                        new ArbitrationData
                        {
                            AssessmentId = Convert.ToInt32(row["AssessmentId"]),
                            ArbitrationId = Convert.ToInt32(row["ArbitrationId"]),
                            ReferralSourceId = Convert.ToInt32(row["ReferralSourceId"]),
                            ReferralSource = Convert.ToString(row["ReferralSource"]),
                            IssueInDisputeId = row.IsNull("IssueInDisputeId") ? (int?)null : Convert.ToInt32(row["IssueInDisputeId"]),
                            IssueInDispute = row.IsNull("IssueInDispute") ? null : Convert.ToString(row["IssueInDispute"]),
                            LawyerId = row.IsNull("LawyerId") ? (int?)null : Convert.ToInt32(row["LawyerId"]),
                            Lawyer = row.IsNull("Lawyer") ? null : Convert.ToString(row["Lawyer"]),
                        })
                    .ToList();
            }
        }

        public IEnumerable<AssessmentTypeCount> GetNumberOfCompletedAssessments(AssessmentTypeCountDataSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var counts = (from at in meta.AssessmentType
                              join ass in meta.Assessment on at.AssessmentTypeId equals ass.AssessmentTypeId
                              where criteria.AssessmentTypeIds.Contains(at.AssessmentTypeId) &&
                              ass.Appointments.Any(app =>
                                  app.AppointmentStatusId == AppointmentStatus.Complete &&
                                  app.AppointmentTime >= criteria.AppointmentTimeMin &&
                                  app.AppointmentTime <= criteria.AppointmentTimeMax
                              )
                              group at by new { at.AssessmentTypeId, at.Name } into g
                              select new { g.Key.AssessmentTypeId, g.Key.Name, Count = g.Count() }
                              );

                return counts
                    .ToList()
                    .Select(c => new AssessmentTypeCount
                    {
                        AssessmentType = new AssessmentType
                        {
                            AssessmentTypeId = c.AssessmentTypeId,
                            Name = c.Name,
                        },
                        Count = c.Count,
                    });
            }
        }
    }
}
