using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Analysis;
using PsychologicalServices.Models.Rights;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/cancellationdata")]
    public class CancellationDataController : ApiController
    {
        private readonly IAnalysisService _analysisService = null;

        public CancellationDataController(
            IAnalysisService analysisService
        )
        {
            _analysisService = analysisService;
        }

        [RightAuthorize(StaticRights.ViewReport)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<CancellationData>))]
        public IHttpActionResult Search(CancellationDataSearchCriteria criteria)
        {
            var data = _analysisService.GetCancellationData(criteria);

            return Ok(data);
        }
    }
}
