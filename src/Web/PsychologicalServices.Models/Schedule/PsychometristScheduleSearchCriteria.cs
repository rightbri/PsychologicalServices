using System;

namespace PsychologicalServices.Models.Schedule
{
    public class PsychometristScheduleSearchCriteria
    {
        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public int CompanyId { get; set; }

        public int? PsychometristId { get; set; }
    }
}
