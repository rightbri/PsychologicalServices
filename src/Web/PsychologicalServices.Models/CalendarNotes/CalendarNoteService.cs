using log4net;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Common.Utility;
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

        public IEnumerable<CalendarNote> GetCalendarNotes(CalendarNoteSearchCriteria criteria)
        {
            var calendarNotes = _calendarNoteRepository.GetCalendarNotes(criteria);

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

        public DeleteResult DeleteCalendarNote(int id)
        {
            var result = new DeleteResult();

            try
            {
                result.IsDeleted = _calendarNoteRepository.DeleteCalendarNote(id);
            }
            catch (Exception ex)
            {
                _log.Error("DeleteCalendarNote", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
