using System;
using System.Collections.Generic;
using PsychologicalServices.Models.Common;
using log4net;

namespace PsychologicalServices.Models.Events
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository = null;
        private readonly IEventValidator _eventValidator = null;
        private readonly ILog _log = null;

        public EventService(
            IEventRepository eventRepository,
            IEventValidator eventValidator,
            ILog log
        )
        {
            _eventRepository = eventRepository;
            _eventValidator = eventValidator;
            _log = log;
        }

        public Event GetEvent(int id)
        {
            var e = _eventRepository.GetEvent(id);

            return e;
        }

        public IEnumerable<Event> GetEvents(EventSearchCriteria criteria)
        {
            var events = _eventRepository.GetEvents(criteria);

            return events;
        }

        public SaveResult<Event> SaveEvent(Event e)
        {
            var result = new SaveResult<Event>();

            try
            {
                var validation = _eventValidator.Validate(e);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _eventRepository.SaveEvent(e);

                    result.Item = _eventRepository.GetEvent(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveEvent", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
