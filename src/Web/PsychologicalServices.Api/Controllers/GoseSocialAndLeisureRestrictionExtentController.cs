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
    [RoutePrefix("api/gosesocialandleisurerestrictionextent")]
    public class GoseSocialAndLeisureRestrictionExtentController : ApiController
    {
        private readonly IGoseService _goseService = null;

        public GoseSocialAndLeisureRestrictionExtentController(
            IGoseService goseService
        )
        {
            _goseService = goseService;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<GoseSocialAndLeisureRestrictionExtent>))]
        public IHttpActionResult Get()
        {
            var result = _goseService.GetSocialAndLeisureRestrictionExtents();

            return Ok(result);
        }
    }
}
