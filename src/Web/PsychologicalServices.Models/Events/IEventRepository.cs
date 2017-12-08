using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Events
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetEvents(EventSearchCriteria criteria);
    }
}
