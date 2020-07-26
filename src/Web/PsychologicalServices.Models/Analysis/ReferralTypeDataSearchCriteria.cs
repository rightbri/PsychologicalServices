using System;

namespace PsychologicalServices.Models.Analysis
{
    public class ReferralTypeDataSearchCriteria
    {
        public int CompanyId { get; set; }

        public DateTimeOffset? StartAppointmentTime { get; set; }

        public DateTimeOffset? EndAppointmentTime { get; set; }
    }
}
