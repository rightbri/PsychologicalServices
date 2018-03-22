using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
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

        [Route("claimants/{claimantId}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Claim>))]
        public IHttpActionResult ClaimantClaims(int claimantId)
        {
            var claims = _claimService.GetClaimsForClaimant(claimantId);

            return Ok(claims);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<Claim>))]
        public IHttpActionResult Save(Claim claim)
        {
            var result = _claimService.SaveClaim(claim);

            return Ok(result);
        }
    }
}
