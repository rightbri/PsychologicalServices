using PsychologicalServices.Models.Analysis;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
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
