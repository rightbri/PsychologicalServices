using System;

namespace PsychologicalServices.Models.CalendarNotes
{
    public static class CalendarNoteExtensions
    {
        public static bool AppliesToDay(this CalendarNote calendarNote, DateTimeOffset day)
        {
            return
                calendarNote.FromDate < day.AddDays(1) &&
                calendarNote.ToDate >= day;
        }
    }
}
