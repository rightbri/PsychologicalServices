using PsychologicalServices.Models.CalendarNotes;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Api.Infrastructure.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PsychologicalServices.Models.Rights;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/calendarNote")]
    public class CalendarNoteController : ApiController
    {
        private readonly ICalendarNoteService _calendarNoteService = null;

        public CalendarNoteController(
            ICalendarNoteService calendarNoteService
        )
        {
            _calendarNoteService = calendarNoteService;
        }

        [RightAuthorize(StaticRights.ViewCalendarNote)]
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(CalendarNote))]
        public IHttpActionResult Get(int id)
        {
            var calendarNote = _calendarNoteService.GetCalendarNote(id);

            return Ok(calendarNote);
        }

        [RightAuthorize(StaticRights.SearchCalendarNote)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<CalendarNote>))]
        public IHttpActionResult Search(CalendarNoteSearchCriteria criteria)
        {
            var calendarNotes = _calendarNoteService.GetCalendarNotes(criteria);

            return Ok(calendarNotes);
        }

        [RightAuthorize(StaticRights.EditCalendarNote)]
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<CalendarNote>))]
        public IHttpActionResult Save(CalendarNote calendarNote)
        {
            var result = _calendarNoteService.SaveCalendarNote(calendarNote);

            return Ok(result);
        }

        [RightAuthorize(StaticRights.DeleteCalendarNote)]
        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(DeleteResult))]
        public IHttpActionResult Delete([FromUri]int id)
        {
            var result = _calendarNoteService.DeleteCalendarNote(id);

            return Ok(result);
        }
    }
}
