using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Analysis;
using PsychologicalServices.Models.Rights;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/researchconsentobtainedclaimantdata")]
    public class ResearchConsentObtainedClaimantDataController : ApiController
    {
        private readonly IAnalysisService _analysisService = null;

        public ResearchConsentObtainedClaimantDataController(
            IAnalysisService analysisService
        )
        {
            _analysisService = analysisService;
        }

        [RightAuthorize(StaticRights.ViewReport)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<ResearchConsentObtainedClaimantData>))]
        public IHttpActionResult Search(ResearchConsentObtainedClaimantDataSearchCriteria criteria)
        {
            var data = _analysisService.GetResearchConsentObtainedClaimantData(criteria);

            return Ok(data);
        }
    }
}
