using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Referrals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
{
    [RoutePrefix("api/referralsource")]
    public class ReferralSourceController : ApiController
    {
        private readonly IReferralService _referralService = null;

        public ReferralSourceController(
            IReferralService referralService
        )
        {
            _referralService = referralService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(ReferralSource))]
        public IHttpActionResult Get(int id)
        {
            var referralSource = _referralService.GetReferralSource(id);

            return Ok(referralSource);
        }

        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<ReferralSource>))]
        public IHttpActionResult Post(ReferralSourceSearchCriteria criteria)
        {
            var referralSources = _referralService.GetReferralSources(criteria);

            return Ok(referralSources);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<ReferralSource>))]
        public IHttpActionResult Save(ReferralSource referralSource)
        {
            var result = _referralService.SaveReferralSource(referralSource);

            return Ok(result);
        }
    }
}
