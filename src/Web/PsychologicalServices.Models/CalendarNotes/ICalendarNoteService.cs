using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.CalendarNotes
{
    public interface ICalendarNoteService
    {
        CalendarNote GetCalendarNote(int id);

        IEnumerable<CalendarNote> GetCalendarNotes(DateTime? fromDate, DateTime? toDate, bool includeDeleted = false);

        SaveResult<CalendarNote> SaveCalendarNote(CalendarNote calendarNote);
    }
}
