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

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Claimant))]
        public IHttpActionResult Get(int id)
        {
            var claimant = _claimService.GetClaimant(id);

            return Ok(claimant);
        }

        [Route("search/{name}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Claimant>))]
        public IHttpActionResult Get(string name)
        {
            var claimants = _claimService.SearchClaimants(name);
            
            return Ok(claimants);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<Claimant>))]
        public IHttpActionResult Save(Claimant claimant)
        {
            var result = _claimService.SaveClaimant(claimant);

            return Ok(result);
        }

        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(DeleteResult))]
        public IHttpActionResult Delete([FromUri]int id)
        {
            var result = _claimService.DeleteClaimant(id);

            return Ok(result);
        }
    }
}
