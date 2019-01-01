using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Companies;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Analysis
{
    public class AnalysisService : IAnalysisService
    {
        private readonly IAnalysisRepository _analysisRepository = null;
        private readonly ICompanyRepository _companyRepository = null;
        private readonly ITimezoneService _timezoneService = null;

        public AnalysisService(
            IAnalysisRepository analysisRepository,
            ICompanyRepository companyRepository,
            ITimezoneService timezoneService
        )
        {
            _analysisRepository = analysisRepository;
            _companyRepository = companyRepository;
            _timezoneService = timezoneService;
        }

        public IEnumerable<BookingData> GetBookingData(BookingDataSearchCriteria criteria)
        {
            var data = _analysisRepository.GetBookingData(criteria);

            return data;
        }

        public IEnumerable<CancellationData> GetCancellationData(CancellationDataSearchCriteria criteria)
        {
            var data = _analysisRepository.GetCancellationData(criteria);

            return data;
        }

        public IEnumerable<CompletionData> GetCompletionData(CompletionDataSearchCriteria criteria)
        {
            var data = _analysisRepository.GetCompletionData(criteria);

            return data;
        }

        public IEnumerable<ArbitrationData> GetArbitrationData(ArbitrationDataSearchCriteria criteria)
        {
            var data = _analysisRepository.GetArbitrationData(criteria);

            return data;
        }

        public IEnumerable<AssessmentTypeCount> GetAssessmentTypeCountsForYear(AssessmentTypeCountSearchCriteria criteria)
        {
            var company = _companyRepository.GetCompany(criteria.CompanyId);
            var timezoneInfo = _timezoneService.GetTimeZoneInfo(company.Timezone);

            var appointmentTimeMin = _timezoneService.GetDateTimeOffset(new DateTime(criteria.Year, 1, 1), timezoneInfo);
            var appointmentTimeMax = _timezoneService.GetDateTimeOffset(new DateTime(criteria.Year, 12, 31), timezoneInfo);

            var repositoryCriteria = new AssessmentTypeCountDataSearchCriteria
            {
                AssessmentTypeIds = criteria.AssessmentTypeIds,
                AppointmentTimeMin = appointmentTimeMin,
                AppointmentTimeMax = appointmentTimeMax,
            };

            var counts = _analysisRepository.GetNumberOfCompletedAssessments(repositoryCriteria);

            return counts;
        }

        public CredibilityData GetCredibilityData(CredibilityDataSearchCriteria criteria)
        {
            var data = _analysisRepository.GetCredibilityData(criteria);

            return data;
        }
    }
}
