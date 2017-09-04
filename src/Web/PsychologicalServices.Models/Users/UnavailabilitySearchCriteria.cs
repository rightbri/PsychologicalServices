using System;

namespace PsychologicalServices.Models.Users
{
    public class UnavailabilitySearchCriteria
    {
        public int? CompanyId { get; set; }

        public DateTimeOffset? UnavailabilityStart { get; set; }

        public DateTimeOffset? UnavailabilityEnd { get; set; }
    }
}
