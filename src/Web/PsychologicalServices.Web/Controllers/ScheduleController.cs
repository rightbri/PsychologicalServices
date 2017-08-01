using PsychologicalServices.Models.Schedule;
using PsychologicalServices.Models.Users;
using PsychologicalServices.Web.Infrastructure.Results;
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

        [Route("week")]
        [HttpPost]
        [ResponseType(typeof(BinaryFileResult))]
        public IHttpActionResult Week(WeekScheduleParameters parameters)
        {
            var result = _scheduleService.GetWeekSchedule(parameters);

            var companyName = System.Text.RegularExpressions.Regex.Replace(result.Company.Name, "[^A-Za-z0-9 ]", "").Replace(' ','-');

            var filename = string.Format("{0}-Schedule-{1:dd-MM-yyyy}-to-{2:dd-MM-yyyy}.pdf", companyName, result.WeekStart, result.WeekEnd);

            return new BinaryFileResult(result.Content, filename);
        }
    }
}
