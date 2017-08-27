using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Outstanding
{
    public class OutstandingService : IOutstandingService
    {
        private readonly IOutstandingRepository _outstandingRepository = null;

        public OutstandingService(
            IOutstandingRepository outstandingRepository
        )
        {
            _outstandingRepository = outstandingRepository;
        }

        public IEnumerable<OutstandingReport> GetOutstandingReports(OutstandingReportSearchCriteria criteria)
        {
            var data = _outstandingRepository.GetOutstandingReports(criteria);

            return data;
        }
    }
}
