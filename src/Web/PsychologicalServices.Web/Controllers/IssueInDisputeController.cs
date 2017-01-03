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
    [RoutePrefix("api/issueindispute")]
    public class IssueInDisputeController : ApiController
    {
        private readonly IClaimService _claimService = null;

        public IssueInDisputeController(
            IClaimService claimService
        )
        {
            _claimService = claimService;
        }
        
        [HttpGet]
        [ResponseType(typeof(IEnumerable<IssueInDispute>))]
        public IHttpActionResult Get()
        {
            var issuesInDispute = _claimService.GetIssuesInDispute();

            return Ok(issuesInDispute);
        }
    }
}
