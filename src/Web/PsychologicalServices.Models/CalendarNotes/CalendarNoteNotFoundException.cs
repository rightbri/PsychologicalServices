using System;

namespace PsychologicalServices.Models.CalendarNotes
{
    public class CalendarNoteNotFoundException : Exception
    {
        private const string MessageFormat = "Calendar note {0} was not found";

        public CalendarNoteNotFoundException(int calendarNoteId)
            : base(string.Format(MessageFormat, calendarNoteId))
        {
        }
    }
}
