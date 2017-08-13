using PsychologicalServices.Models.CalendarNotes;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Web.Infrastructure.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
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

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(CalendarNote))]
        public IHttpActionResult Get(int id)
        {
            var calendarNote = _calendarNoteService.GetCalendarNote(id);

            return Ok(calendarNote);
        }

        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<CalendarNote>))]
        public IHttpActionResult Search(CalendarNoteSearchCriteria criteria)
        {
            var calendarNotes = _calendarNoteService.GetCalendarNotes(criteria);

            return Ok(calendarNotes);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<CalendarNote>))]
        public IHttpActionResult Save(CalendarNote calendarNote)
        {
            var result = _calendarNoteService.SaveCalendarNote(calendarNote);

            return Ok(result);
        }

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
