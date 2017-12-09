using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Events
{
    public interface IEventService
    {
        Event GetEvent(int id);

        IEnumerable<Event> GetEvents(EventSearchCriteria criteria);

        SaveResult<Event> SaveEvent(Event e);
    }
}
