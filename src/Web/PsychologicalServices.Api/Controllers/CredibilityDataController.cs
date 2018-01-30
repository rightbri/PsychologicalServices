using PsychologicalServices.Models.Analysis;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/credibilitydata")]
    public class CredibilityDataController : ApiController
    {
        private readonly IAnalysisService _analysisService = null;

        public CredibilityDataController(
            IAnalysisService analysisService
        )
        {
            _analysisService = analysisService;
        }
        
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<CredibilityData>))]
        public IHttpActionResult Search(CredibilityDataSearchCriteria criteria)
        {
            var data = _analysisService.GetCredibilityData(criteria);

            return Ok(data);
        }
    }
}
