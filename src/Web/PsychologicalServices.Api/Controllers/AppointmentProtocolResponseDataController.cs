using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Analysis;
using PsychologicalServices.Models.Rights;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/appointmentprotocolresponsedata")]
    public class AppointmentProtocolResponseDataController : ApiController
    {
        private readonly IAnalysisService _analysisService = null;

        public AppointmentProtocolResponseDataController(
            IAnalysisService analysisService
        )
        {
            _analysisService = analysisService;
        }

        [RightAuthorize(StaticRights.ViewReport)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<AppointmentProtocolResponseData>))]
        public IHttpActionResult Search(AppointmentProtocolResponseDataSearchCriteria criteria)
        {
            var data = _analysisService.GetAppointmentProtocolResponseData(criteria);

            return Ok(data);
        }
    }
}
