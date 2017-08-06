using System;

namespace PsychologicalServices.Models.Schedule
{
    public class PsychometristScheduleSearchCriteria
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CompanyId { get; set; }

        public int? PsychometristId { get; set; }
    }
}
