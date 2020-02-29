using PsychologicalServices.Models.Gose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/gosereturntonormallifeoutcomefactor")]
    public class GoseReturnToNormalLifeOutcomeFactorController : ApiController
    {
        private readonly IGoseService _goseService = null;

        public GoseReturnToNormalLifeOutcomeFactorController(
            IGoseService goseService
        )
        {
            _goseService = goseService;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<GoseReturnToNormalLifeOutcomeFactor>))]
        public IHttpActionResult Get()
        {
            var result = _goseService.GetReturnToNormalLifeOutcomeFactors();

            return Ok(result);
        }
    }
}
