using PsychologicalServices.Models.Credibilities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/credibility")]
    public class CredibilityController : ApiController
    {
        private readonly ICredibilityService _credibilityService = null;

        public CredibilityController(
            ICredibilityService credibilityService
        )
        {
            _credibilityService = credibilityService;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<Credibility>))]
        public IHttpActionResult Get()
        {
            var credibilities = _credibilityService.GetCredibilities();

            return Ok(credibilities);
        }

    }
}
