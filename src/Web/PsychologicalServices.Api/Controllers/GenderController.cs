using PsychologicalServices.Models.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/gender")]
    public class GenderController : ApiController
    {
        private readonly IClaimService _claimService = null;

        public GenderController(
            IClaimService claimService
        )
        {
            _claimService = claimService;
        }

        [HttpGet]
        [ResponseType(typeof(IDictionary<string, string>))]
        public IHttpActionResult Get()
        {
            var genders = _claimService.GetGenders();

            return Ok(genders);
        }
    }
}
