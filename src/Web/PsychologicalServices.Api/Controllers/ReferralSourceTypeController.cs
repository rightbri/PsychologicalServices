using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Referrals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/referralsourcetype")]
    public class ReferralSourceTypeController : ApiController
    {
        private readonly IReferralService _referralService = null;

        public ReferralSourceTypeController(
            IReferralService referralService
        )
        {
            _referralService = referralService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(ReferralSourceType))]
        public IHttpActionResult Get(int id)
        {
            var referralSourceType = _referralService.GetReferralSourceType(id);

            return Ok(referralSourceType);
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<ReferralSourceType>))]
        public IHttpActionResult Get()
        {
            var referralSourceTypes = _referralService.GetReferralSourceTypes();

            return Ok(referralSourceTypes);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<ReferralSourceType>))]
        public IHttpActionResult Save(ReferralSourceType referralSourceType)
        {
            var result = _referralService.SaveReferralSourceType(referralSourceType);

            return Ok(result);
        }
    }
}
