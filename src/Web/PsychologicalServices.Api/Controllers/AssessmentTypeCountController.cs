using PsychologicalServices.Models.Analysis;
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
