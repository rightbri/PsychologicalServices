using PsychologicalServices.Models.CalendarNotes;
using PsychologicalServices.Models.Common;
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

        [HttpGet]
        [ResponseType(typeof(IEnumerable<CalendarNote>))]
        public IHttpActionResult Get(DateTime? fromDate, DateTime? toDate, bool includeDeleted = false)
        {
            var calendarNotes = _calendarNoteService.GetCalendarNotes(fromDate, toDate, includeDeleted);

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
    }
}
