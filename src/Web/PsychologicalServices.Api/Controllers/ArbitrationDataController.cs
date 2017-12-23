using PsychologicalServices.Models.Analysis;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/arbitrationdata")]
    public class ArbitrationDataController : ApiController
    {
        private readonly IAnalysisService _analysisService = null;

        public ArbitrationDataController(
            IAnalysisService analysisService
        )
        {
            _analysisService = analysisService;
        }
        
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<ArbitrationData>))]
        public IHttpActionResult Search(ArbitrationDataSearchCriteria criteria)
        {
            var data = _analysisService.GetArbitrationData(criteria);

            return Ok(data);
        }
    }
}
