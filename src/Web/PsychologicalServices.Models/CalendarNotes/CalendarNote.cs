using PsychologicalServices.Models.Notes;
using System;

namespace PsychologicalServices.Models.CalendarNotes
{
    public class CalendarNote
    {
        public int CalendarNoteId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int NoteId { get; set; }

        public Note Note { get; set; }

        public bool IsNew()
        {
            return CalendarNoteId == 0;
        }
    }
}
