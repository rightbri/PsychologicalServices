using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Consulting;
using PsychologicalServices.Models.Rights;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/consultingagreement")]
    public class ConsultingAgreementController : ApiController
    {
        private readonly IConsultingService _consultingService = null;

        public ConsultingAgreementController(
            IConsultingService consultingService
        )
        {
            _consultingService = consultingService;
        }

        [RightAuthorize(StaticRights.SearchReferralSource)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<ConsultingAgreement>))]
        public IHttpActionResult Post(ConsultingAgreementSearchCriteria criteria)
        {
            var consultingAgreements = _consultingService.GetConsultingAgreements(criteria);

            return Ok(consultingAgreements);
        }
    }
}
