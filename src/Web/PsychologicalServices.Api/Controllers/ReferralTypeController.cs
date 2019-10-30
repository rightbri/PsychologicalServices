using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Referrals;
using PsychologicalServices.Models.Rights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/referraltype")]
    public class ReferralTypeController : ApiController
    {
        private readonly IReferralService _referralService = null;

        public ReferralTypeController(
            IReferralService referralService
        )
        {
            _referralService = referralService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(ReferralType))]
        public IHttpActionResult Get(int id)
        {
            var referralType = _referralService.GetReferralType(id);

            return Ok(referralType);
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<ReferralType>))]
        public IHttpActionResult Get()
        {
            var referralTypes = _referralService.GetReferralTypes();

            return Ok(referralTypes);
        }

        [RightAuthorize(StaticRights.EditReferralType)]
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<ReferralType>))]
        public IHttpActionResult Save(ReferralType referralType)
        {
            var result = _referralService.SaveReferralType(referralType);

            return Ok(result);
        }
    }
}
