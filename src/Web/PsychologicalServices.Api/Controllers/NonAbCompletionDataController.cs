using PsychologicalServices.Models.Analysis;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/nonabcompletiondata")]
    public class NonAbCompletionDataController : ApiController
    {
        private readonly IAnalysisService _analysisService = null;

        public NonAbCompletionDataController(
            IAnalysisService analysisService
        )
        {
            _analysisService = analysisService;
        }
        
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<NonAbCompletionData>))]
        public IHttpActionResult Search(NonAbCompletionDataSearchCriteria criteria)
        {
            var data = _analysisService.GetNonAbCompletionData(criteria);

            return Ok(data);
        }
    }
}
