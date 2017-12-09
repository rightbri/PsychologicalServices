using PsychologicalServices.Data;
using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Events;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Events
{
    public class EventRepository : RepositoryBase, IEventRepository
    {
        private readonly IDate _date = null;

        public EventRepository(
            IDataAccessAdapterFactory adapterFactory,
            IDate date
        ) : base(adapterFactory)
        {
            _date = date;
        }
        
        public Event GetEvent(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Event
                    .Where(e => e.EventId == id)
                    .SingleOrDefault()
                    .ToEvent();
            }
        }

        public IEnumerable<Event> GetEvents(EventSearchCriteria criteria)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                var events = meta.Event.AsQueryable();

                if (!string.IsNullOrWhiteSpace(criteria.Description))
                {
                    events = events.Where(e => e.Description.Contains(criteria.Description));
                }

                if (!string.IsNullOrWhiteSpace(criteria.Location))
                {
                    events = events.Where(e => e.Location.Contains(criteria.Location));
                }

                if (criteria.IsExpired.HasValue)
                {
                    var now = _date.UtcNow;

                    if (criteria.IsExpired.Value)
                    {
                        events = events.Where(e => e.Expires <= now);
                    }
                    else
                    {
                        events = events.Where(e => e.Expires > now);
                    }
                }

                if (criteria.IsActive.HasValue)
                {
                    events = events.Where(e => e.IsActive == criteria.IsActive);
                }
                
                return Execute<EventEntity>(
                    (ILLBLGenProQuery)
                    events
                    )
                    .Select(e => e.ToEvent())
                    .ToList();
            }
        }

        public int SaveEvent(Event e)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = e.IsNew();

                var entity = new EventEntity
                {
                    IsNew = isNew,
                    EventId = e.EventId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.Description = e.Description;

                if (string.IsNullOrWhiteSpace(e.Location))
                {
                    entity.SetNewFieldValue((int)EventFieldIndex.Location, null);
                }
                else
                {
                    entity.Location = e.Location;
                }

                if (string.IsNullOrWhiteSpace(e.Time))
                {
                    entity.SetNewFieldValue((int)EventFieldIndex.Time, null);
                }
                else
                {
                    entity.Time = e.Time;
                }

                if (string.IsNullOrWhiteSpace(e.Url))
                {
                    entity.SetNewFieldValue((int)EventFieldIndex.Url, null);
                }
                else
                {
                    entity.Url = e.Url;
                }

                entity.Expires = e.Expires;
                entity.IsActive = e.IsActive;

                adapter.SaveEntity(entity, false);

                return entity.EventId;
            }
        }
    }
}
