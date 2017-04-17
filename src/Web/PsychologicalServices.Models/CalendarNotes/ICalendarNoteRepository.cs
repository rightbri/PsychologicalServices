using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.CalendarNotes
{
    public interface ICalendarNoteRepository
    {
        CalendarNote GetCalendarNote(int id);

        IEnumerable<CalendarNote> GetCalendarNotes(DateTime? fromDate, DateTime? toDate);

        int SaveCalendarNote(CalendarNote calendarNote);
    }
}
