using PsychologicalServices.Models.Schedule;
using PsychologicalServices.Models.Users;
using PsychologicalServices.Api.Infrastructure.Results;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
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
        public IHttpActionResult PsychometristSearch(PsychometristScheduleSearchCriteria criteria)
        {
            var users = _scheduleService.SearchPsychometristSchedules(criteria);

            return Ok(users);
        }

        [Route("send")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<PsychometristScheduleSendResult>))]
        public IHttpActionResult PsychometristSend(PsychometristScheduleSendParameters parameters)
        {
            var results = _scheduleService.SendPsychometristSchedule(parameters);

            return Ok(results);
        }

        [Route("psychologist")]
        [HttpPost]
        [ResponseType(typeof(BinaryFileResult))]
        public IHttpActionResult Psychologist(PsychologistScheduleParameters parameters)
        {
            var result = _scheduleService.GetPsychologistSchedule(parameters);

            var companyName = System.Text.RegularExpressions.Regex.Replace(result.Psychologist.Company.Name, "[^A-Za-z0-9]", "").Replace(' ','-');

            var filename = string.Format("{0}-Schedule-{1:dd-MM-yyyy}-to-{2:dd-MM-yyyy}.pdf", companyName, result.FromDate, result.ToDate);

            return new BinaryFileResult(result.Content, filename);
        }
    }
}
