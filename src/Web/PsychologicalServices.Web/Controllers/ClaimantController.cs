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
    [RoutePrefix("api/claimant")]
    public class ClaimantController : ApiController
    {
        private readonly IClaimService _claimService = null;

        public ClaimantController(
            IClaimService claimService
        )
        {
            _claimService = claimService;
        }

        [Route("search/{lastName}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Claimant>))]
        public IHttpActionResult Get(string lastName)
        {
            var claimants = _claimService.SearchClaimants(lastName);
            
            return Ok(claimants);
        }
    }
}
