using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Analysis;
using PsychologicalServices.Models.Rights;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/assessmenttypecount")]
    public class AssessmentTypeCountController : ApiController
    {
        private readonly IAnalysisService _analysisService = null;

        public AssessmentTypeCountController(
            IAnalysisService analysisService
        )
        {
            _analysisService = analysisService;
        }

        [RightAuthorize(StaticRights.ViewReport)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<AssessmentTypeCount>))]
        public IHttpActionResult Search(AssessmentTypeCountSearchCriteria criteria)
        {
            var data = _analysisService.GetAssessmentTypeCountsForYear(criteria);

            return Ok(data);
        }
    }
}
