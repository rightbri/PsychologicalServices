using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Analysis;
using PsychologicalServices.Models.Rights;
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

        [RightAuthorize(StaticRights.ViewReport)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(CredibilityData))]
        public IHttpActionResult Search(CredibilityDataSearchCriteria criteria)
        {
            var data = _analysisService.GetCredibilityData(criteria);

            return Ok(data);
        }
    }
}
