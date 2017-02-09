using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
{
    [RoutePrefix("api/claim")]
    public class ClaimController : ApiController
    {
        private readonly IClaimService _claimService = null;

        public ClaimController(
            IClaimService claimService
        )
        {
            _claimService = claimService;
        }

        [Route("assessment/{assessmentId}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Claim>))]
        public IHttpActionResult AssessmentClaims(int assessmentId)
        {
            var assessmentClaims = _claimService.GetAssessmentClaims(assessmentId);

            return Ok(assessmentClaims);
        }
    }
}
