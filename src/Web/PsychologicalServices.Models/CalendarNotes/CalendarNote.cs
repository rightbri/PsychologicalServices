using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Notes;
using System;

namespace PsychologicalServices.Models.CalendarNotes
{
    public class CalendarNote
    {
        public int CalendarNoteId { get; set; }

        public DateTimeOffset FromDate { get; set; }

        public DateTimeOffset ToDate { get; set; }

        public Note Note { get; set; }

        public Company Company { get; set; }

        public bool IsNew()
        {
            return CalendarNoteId == 0;
        }
    }
}
