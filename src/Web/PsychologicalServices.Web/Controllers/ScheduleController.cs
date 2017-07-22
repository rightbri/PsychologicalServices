using PsychologicalServices.Models.Schedule;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
{
    [RoutePrefix("api/schedule")]
    public class ScheduleController : ApiController
    {
        private readonly IScheduleService _scheduleService = null;

        public ScheduleController(
            IScheduleService scheduleService
        )
        {
            _scheduleService = scheduleService;
        }

        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult Search(ScheduleSearchCriteria criteria)
        {
            var users = _scheduleService.Search(criteria);

            return Ok(users);
        }

        [Route("send")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<SendScheduleResult>))]
        public IHttpActionResult Send(ScheduleSendParameters parameters)
        {
            var results = _scheduleService.SendSchedule(parameters);

            return Ok(results);
        }
    }
}
