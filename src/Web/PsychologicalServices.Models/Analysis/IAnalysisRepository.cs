using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Analysis
{
    public interface IAnalysisRepository
    {
        IEnumerable<BookingData> GetBookingData(BookingDataSearchCriteria criteria);

        IEnumerable<CancellationData> GetCancellationData(CancellationDataSearchCriteria criteria);

        IEnumerable<CompletionData> GetCompletionData(CompletionDataSearchCriteria criteria);

        IEnumerable<ArbitrationData> GetArbitrationData(ArbitrationDataSearchCriteria criteria);

        IEnumerable<AssessmentTypeCount> GetNumberOfCompletedAssessments(AssessmentTypeCountDataSearchCriteria criteria);
    }
}
