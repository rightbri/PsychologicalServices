using PsychologicalServices.Models.Events;
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

    }
}
