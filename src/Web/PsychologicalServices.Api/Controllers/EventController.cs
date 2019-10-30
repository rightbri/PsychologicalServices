using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Events;
using PsychologicalServices.Models.Rights;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/event")]
    public class EventController : ApiController
    {
        private readonly IEventService _eventService = null;

        public EventController(
            IEventService eventService
        )
        {
            _eventService = eventService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Event))]
        public IHttpActionResult Get(int id)
        {
            var e = _eventService.GetEvent(id);

            return Ok(e);
        }

        [AllowAnonymous]
        [OverrideAuthorization]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<Event>))]
        public IHttpActionResult Search(EventSearchCriteria criteria)
        {
            var events = _eventService.GetEvents(criteria);

            return Ok(events);
        }

        [RightAuthorize(StaticRights.EditEvent)]
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<Event>))]
        public IHttpActionResult Save(Event e)
        {
            var result = _eventService.SaveEvent(e);

            return Ok(result);
        }
    }
}
