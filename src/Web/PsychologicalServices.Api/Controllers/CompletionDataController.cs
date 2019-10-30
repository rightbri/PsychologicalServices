using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Analysis;
using PsychologicalServices.Models.Rights;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/completiondata")]
    public class CompletionDataController : ApiController
    {
        private readonly IAnalysisService _analysisService = null;

        public CompletionDataController(
            IAnalysisService analysisService
        )
        {
            _analysisService = analysisService;
        }

        [RightAuthorize(StaticRights.ViewReport)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<CompletionData>))]
        public IHttpActionResult Search(CompletionDataSearchCriteria criteria)
        {
            var data = _analysisService.GetCompletionData(criteria);

            return Ok(data);
        }
    }
}
