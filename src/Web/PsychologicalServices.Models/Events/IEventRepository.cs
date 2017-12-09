using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Events
{
    public interface IEventRepository
    {
        Event GetEvent(int id);

        IEnumerable<Event> GetEvents(EventSearchCriteria criteria);

        int SaveEvent(Event e);
    }
}
