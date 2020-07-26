using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Analysis;
using PsychologicalServices.Models.Rights;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/referraltypedata")]
    public class ReferralTypeDataController : ApiController
    {
        private readonly IAnalysisService _analysisService = null;

        public ReferralTypeDataController(
            IAnalysisService analysisService
        )
        {
            _analysisService = analysisService;
        }

        [RightAuthorize(StaticRights.ViewReport)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<ReferralTypeData>))]
        public IHttpActionResult Search(ReferralTypeDataSearchCriteria criteria)
        {
            var data = _analysisService.GetReferralTypeData(criteria);

            return Ok(data);
        }
    }
}
