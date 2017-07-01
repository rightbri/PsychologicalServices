using log4net;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.CalendarNotes
{
    public class CalendarNoteService : ICalendarNoteService
    {
        private readonly ICalendarNoteRepository _calendarNoteRepository = null;
        private readonly ICalendarNoteValidator _calendarNoteValidator = null;
        private readonly ILog _log = null;

        public CalendarNoteService(
            ICalendarNoteRepository calendarNoteRepository,
            ICalendarNoteValidator calendarNoteValidator,
            ILog log
        )
        {
            _calendarNoteRepository = calendarNoteRepository;
            _calendarNoteValidator = calendarNoteValidator;
            _log = log;
        }

        public CalendarNote GetCalendarNote(int id)
        {
            var calendarNote = _calendarNoteRepository.GetCalendarNote(id);

            if (null == calendarNote)
            {
                throw new CalendarNoteNotFoundException(id);
            }

            return calendarNote;
        }

        public IEnumerable<CalendarNote> GetCalendarNotes(DateTime? fromDate, DateTime? toDate)
        {
            var calendarNotes = _calendarNoteRepository.GetCalendarNotes(fromDate, toDate);

            return calendarNotes;
        }

        public SaveResult<CalendarNote> SaveCalendarNote(CalendarNote calendarNote)
        {
            var result = new SaveResult<CalendarNote>();

            try
            {
                var validation = _calendarNoteValidator.Validate(calendarNote);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _calendarNoteRepository.SaveCalendarNote(calendarNote);

                    result.Item = _calendarNoteRepository.GetCalendarNote(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveCalendarNote", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
