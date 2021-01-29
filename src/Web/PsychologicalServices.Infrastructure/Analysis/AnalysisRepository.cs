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

        public IEnumerable<ReferralTypeData> GetReferralTypeData(ReferralTypeDataSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var table = RetrievalProcedures.ReferralTypeData(criteria.CompanyId, criteria.StartAppointmentTime, criteria.EndAppointmentTime, (DataAccessAdapter)adapter);

                return table
                    .AsEnumerable()
                    .Select(row =>
                        new ReferralTypeData
                        {
                            AssessmentId = Convert.ToInt32(row["AssessmentId"]),
                            AppointmentTime = (DateTimeOffset)row["AppointmentTime"],
                            IsDefense = Convert.ToBoolean(row["IsDefense"]),
                            IsPlaintiff = Convert.ToBoolean(row["IsPlaintiff"]),
                            ReferralType = Convert.ToString(row["ReferralType"]),
                            Year = Convert.ToInt32(row["Year"]),
                            Month = Convert.ToInt32(row["Month"]),
                        }
                    );
            }
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
                            InsuranceCompany = Convert.ToString(row["InsuranceCompany"]),
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
                var table = RetrievalProcedures.CompletionData(criteria.CompanyId, criteria.StartAppointmentTime, criteria.EndAppointmentTime, (DataAccessAdapter)adapter);

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

        public CredibilityData GetCredibilityData(CredibilityDataSearchCriteria criteria)
        {
            var data = new CredibilityData();

            using (var adapter = AdapterFactory.CreateAdapter())
            {
                using (var reader = adapter.FetchDataReader(
                    RetrievalProcedures.GetCredibilityDataCallAsQuery(criteria.CompanyId),
                    CommandBehavior.CloseConnection
                ))
                {
                    var details = new List<CredibilityDetail>();

                    while (reader.Read())
                    {
                        details.Add(
                            new CredibilityDetail
                            {
                                AssessmentTypeId = Convert.ToInt32(reader["AssessmentTypeId"]),
                                AssessmentTypeName = Convert.ToString(reader["AssessmentTypeName"]),
                                CountNeurocognitiveCredibility = Convert.ToBoolean(reader["CountNeurocognitiveCredibility"]),
                                CountPsychologicalCredibility = Convert.ToBoolean(reader["CountPsychologicalCredibility"]),
                                DiagnosisFoundNo = Convert.ToBoolean(reader["DiagnosisFoundNo"]),
                                DiagnosisFoundRuleOut = Convert.ToBoolean(reader["DiagnosisFoundRuleOut"]),
                                DiagnosisFoundYes = Convert.ToBoolean(reader["DiagnosisFoundYes"]),
                                NeurocognitiveCredibilityCredible = Convert.ToBoolean(reader["NeurocognitiveCredibilityCredible"]),
                                NeurocognitiveCredibilityNotCredible = Convert.ToBoolean(reader["NeurocognitiveCredibilityNotCredible"]),
                                NeurocognitiveCredibilityQuestionable = Convert.ToBoolean(reader["NeurocognitiveCredibilityQuestionable"]),
                                PsychologicalCredibilityCredible = Convert.ToBoolean(reader["PsychologicalCredibilityCredible"]),
                                PsychologicalCredibilityNotCredible = Convert.ToBoolean(reader["PsychologicalCredibilityNotCredible"]),
                                PsychologicalCredibilityQuestionable = Convert.ToBoolean(reader["PsychologicalCredibilityQuestionable"]),
                                PsychologistFoundInFavorOfClaimantNo = Convert.ToBoolean(reader["PsychologistFoundInFavorOfClaimantNo"]),
                                PsychologistFoundInFavorOfClaimantUnknown = Convert.ToBoolean(reader["PsychologistFoundInFavorOfClaimantUnknown"]),
                                PsychologistFoundInFavorOfClaimantYes = Convert.ToBoolean(reader["PsychologistFoundInFavorOfClaimantYes"]),
                            });
                    }

                    data.CredibilityDetailData = details;

                    if (reader.NextResult())
                    {
                        var credibilityByYearSummaries = new List<CredibilityByYearSummary>();

                        while (reader.Read())
                        {
                            credibilityByYearSummaries.Add(
                                new CredibilityByYearSummary
                                {
                                    Type = Convert.ToString(reader["Type"]),
                                    Year = Convert.ToInt32(reader["Year"]),
                                    CredibilityTotal = Convert.ToDecimal(reader["CredibilityTotal"]),
                                    Credible = Convert.ToDecimal(reader["Credible"]),
                                    NotCredible = Convert.ToDecimal(reader["NotCredible"]),
                                    Questionable = Convert.ToDecimal(reader["Questionable"]),
                                    CredibleRate = Convert.ToDecimal(reader["CredibleRate"]),
                                    NotCredibleRate = Convert.ToDecimal(reader["NotCredibleRate"]),
                                    QuestionableRate = Convert.ToDecimal(reader["QuestionableRate"]),
                                });
                        }

                        data.CredibilityByYearSummaryData = credibilityByYearSummaries;
                    }

                    if (reader.NextResult())
                    {
                        var notCredibleByYearSummaries = new List<NotCredibleByYearSummary>();

                        while (reader.Read())
                        {
                            notCredibleByYearSummaries.Add(
                                new NotCredibleByYearSummary
                                {
                                    Type = Convert.ToString(reader["Type"]),
                                    Year = Convert.ToInt32(reader["Year"]),
                                    Count = Convert.ToInt32(reader["Count"]),
                                    WithReader = Convert.ToDecimal(reader["WithReader"]),
                                    WithoutReader = Convert.ToDecimal(reader["WithoutReader"]),
                                    WithTranslator = Convert.ToDecimal(reader["WithTranslator"]),
                                    WithoutTranslator = Convert.ToDecimal(reader["WithoutTranslator"]),
                                    WithReaderRate = Convert.ToDecimal(reader["WithReaderRate"]),
                                    WithoutReaderRate = Convert.ToDecimal(reader["WithoutReaderRate"]),
                                    WithTranslatorRate = Convert.ToDecimal(reader["WithTranslatorRate"]),
                                    WithoutTranslatorRate = Convert.ToDecimal(reader["WithoutTranslatorRate"]),
                                });
                        }

                        data.NotCredibleByYearSummaryData = notCredibleByYearSummaries;
                    }

                    if (reader.NextResult())
                    {
                        var credibilityByPsychometristSummaries = new List<CredibilityByPsychometristSummary>();

                        while (reader.Read())
                        {
                            credibilityByPsychometristSummaries.Add(
                                new CredibilityByPsychometristSummary
                                {
                                    Type = Convert.ToString(reader["Type"]),
                                    Year = Convert.ToInt32(reader["Year"]),
                                    Psychometrist = Convert.ToString(reader["Psychometrist"]),
                                    Credible = Convert.ToDecimal(reader["Credible"]),
                                    NotCredible = Convert.ToDecimal(reader["NotCredible"]),
                                    Questionable = Convert.ToDecimal(reader["Questionable"]),
                                    CredibleRate = Convert.ToDecimal(reader["CredibleRate"]),
                                    NotCredibleRate = Convert.ToDecimal(reader["NotCredibleRate"]),
                                    QuestionableRate = Convert.ToDecimal(reader["QuestionableRate"]),
                                });
                        }

                        data.CredibilityByPsychometristSummaryData = credibilityByPsychometristSummaries;
                    }
                }
            }

            return data;
        }

        public IEnumerable<NonAbCompletionData> GetNonAbCompletionData(NonAbCompletionDataSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var table = RetrievalProcedures.NonAbcompletionData(criteria.CompanyId, criteria.Months, (DataAccessAdapter)adapter);

                return table
                    .AsEnumerable()
                    .Select(row =>
                        new NonAbCompletionData
                        {
                            AssessmentId = Convert.ToInt32(row["AssessmentId"]),
                            AssessmentType = Convert.ToString(row["AssessmentType"]),
                            ReferralType = Convert.ToString(row["ReferralType"]),
                            AppointmentTime = DateTimeOffset.Parse(Convert.ToString(row["AppointmentTime"])),
                            AppointmentYear = Convert.ToInt32(row["AppointmentYear"]),
                            AppointmentMonth = Convert.ToInt32(row["AppointmentMonth"]),
                            AppointmentStatus = Convert.ToString(row["AppointmentStatus"]),
                            ClaimantFirstName = Convert.ToString(row["FirstName"]),
                            ClaimantLastName = Convert.ToString(row["LastName"])
                        })
                    .ToList();
            }
        }

        public IEnumerable<ResearchConsentObtainedClaimantData> GetResearchConsentObtainedClaimantData(ResearchConsentObtainedClaimantDataSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var table = RetrievalProcedures.ResearchConsentObtainedClaimantData(criteria.CompanyId, (DataAccessAdapter)adapter);

                return table
                    .AsEnumerable()
                    .Select(row =>
                        new ResearchConsentObtainedClaimantData
                        {
                            ClaimantId = Convert.ToInt32(row["ClaimantId"]),
                            FirstName = Convert.ToString(row["FirstName"]),
                            LastName = Convert.ToString(row["LastName"]),
                            Gender = Convert.ToString(row["Gender"]),
                            DateOfBirth = DateTimeOffset.Parse(Convert.ToString(row["DateOfBirth"])),
                            ReferralSource = Convert.ToString(row["ReferralSource"]),
                            AppointmentTime = DateTimeOffset.Parse(Convert.ToString(row["AppointmentTime"])),
                        })
                    .ToList();
            }
        }

        public IEnumerable<AppointmentProtocolResponseData> GetAppointmentProtocolResponseData(AppointmentProtocolResponseDataSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var table = RetrievalProcedures.AppointmentProtocolResponseData(criteria.CompanyId, criteria.Months, (DataAccessAdapter)adapter);

                return table
                    .AsEnumerable()
                    .Select(row =>
                        new AppointmentProtocolResponseData
                        {
                            PsychometristId = Convert.ToInt32(row["PsychometristId"]),
                            PsychometristFirstName = Convert.ToString(row["PsychometristFirstName"]),
                            PsychometristLastName = Convert.ToString(row["PsychometristLastName"]),
                            AppointmentId = Convert.ToInt32(row["AppointmentId"]),
                            AssessmentId = Convert.ToInt32(row["AssessmentId"]),
                            AppointmentTime = DateTimeOffset.Parse(Convert.ToString(row["AppointmentTime"])),
                            ClaimantId = Convert.ToInt32(row["ClaimantId"]),
                            ClaimantFirstName = Convert.ToString(row["ClaimantFirstName"]),
                            ClaimantLastName = Convert.ToString(row["ClaimantLastName"]),
                            Question = Convert.ToString(row["Question"]),
                            Response = row["Response"] != DBNull.Value ? Convert.ToInt32(row["Response"]) : (int?)null,
                        })
                    .ToList();
            }
        }
    }
}
