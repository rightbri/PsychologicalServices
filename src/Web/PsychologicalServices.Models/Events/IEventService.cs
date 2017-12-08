using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Events
{
    public interface IEventService
    {
        IEnumerable<Event> GetEvents(EventSearchCriteria criteria);
    }
}
