using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.CalendarNotes
{
    public interface ICalendarNoteRepository
    {
        CalendarNote GetCalendarNote(int id);

        IEnumerable<CalendarNote> GetCalendarNotes(CalendarNoteSearchCriteria criteria);

        int SaveCalendarNote(CalendarNote calendarNote);

        bool DeleteCalendarNote(int id);
    }
}
