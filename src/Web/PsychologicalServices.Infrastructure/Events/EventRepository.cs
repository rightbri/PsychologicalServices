using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Events;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Events
{
    public class EventRepository : RepositoryBase, IEventRepository
    {
        public EventRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        public IEnumerable<Event> GetEvents(EventSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var events = meta.Event.AsQueryable();

                if (criteria.IsActive.HasValue)
                {
                    events = events.Where(e => e.IsActive == criteria.IsActive);
                }

                if (criteria.FromDate.HasValue)
                {
                    events = events.Where(e => e.Date >= criteria.FromDate);
                }

                if (criteria.ToDate.HasValue)
                {
                    events = events.Where(e => e.Date <= criteria.ToDate);
                }

                return Execute<EventEntity>(
                    (ILLBLGenProQuery)
                    events
                    )
                    .Select(e => e.ToEvent())
                    .ToList();
            }
        }
    }
}
