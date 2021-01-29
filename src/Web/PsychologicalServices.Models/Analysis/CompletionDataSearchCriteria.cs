using System;

namespace PsychologicalServices.Models.Analysis
{
    public class CompletionDataSearchCriteria
    {
        public int CompanyId { get; set; }

        public int? Months { get; set; }

        public DateTimeOffset? StartAppointmentTime { get; set; }

        public DateTimeOffset? EndAppointmentTime { get; set; }
    }
}
