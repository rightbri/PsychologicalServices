using System;

namespace PsychologicalServices.Models.CalendarNotes
{
    public class CalendarNoteSearchCriteria
    {
        public DateTimeOffset? FromDate { get; set; }

        public DateTimeOffset? ToDate { get; set; }

        public int? CompanyId { get; set; }
    }
}
