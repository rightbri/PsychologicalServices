using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Analysis
{
    public class AnalysisService : IAnalysisService
    {
        private readonly IAnalysisRepository _analysisRepository = null;

        public AnalysisService(
            IAnalysisRepository analysisRepository
        )
        {
            _analysisRepository = analysisRepository;
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
    }
}
