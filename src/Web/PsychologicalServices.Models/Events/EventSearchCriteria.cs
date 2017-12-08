using System;

namespace PsychologicalServices.Models.Events
{
    public class EventSearchCriteria
    {
        public DateTimeOffset? FromDate { get; set; }

        public DateTimeOffset? ToDate { get; set; }

        public bool? IsActive { get; set; }
    }
}
