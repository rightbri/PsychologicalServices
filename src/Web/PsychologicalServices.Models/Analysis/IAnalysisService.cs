using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Analysis
{
    public interface IAnalysisService
    {
        IEnumerable<BookingData> GetBookingData(BookingDataSearchCriteria criteria);

        IEnumerable<CancellationData> GetCancellationData(CancellationDataSearchCriteria criteria);

        IEnumerable<CompletionData> GetCompletionData(CompletionDataSearchCriteria criteria);
    }
}
