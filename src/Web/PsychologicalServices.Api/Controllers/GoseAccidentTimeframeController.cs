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
    [RoutePrefix("api/goseaccidenttimeframe")]
    public class GoseAccidentTimeframeController : ApiController
    {
        private readonly IGoseService _goseService = null;

        public GoseAccidentTimeframeController(
            IGoseService goseService
        )
        {
            _goseService = goseService;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<GoseAccidentTimeframe>))]
        public IHttpActionResult Get()
        {
            var result = _goseService.GetAccidentTimeframes();

            return Ok(result);
        }
    }
}
