using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Events
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository = null;

        public EventService(
            IEventRepository eventRepository
        )
        {
            _eventRepository = eventRepository;
        }

        public IEnumerable<Event> GetEvents(EventSearchCriteria criteria)
        {
            var events = _eventRepository.GetEvents(criteria);

            return events;
        }
    }
}
