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
    [RoutePrefix("api/goserespondenttype")]
    public class GoseRespondentTypeController : ApiController
    {
        private readonly IGoseService _goseService = null;

        public GoseRespondentTypeController(
            IGoseService goseService
        )
        {
            _goseService = goseService;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<GoseRespondentType>))]
        public IHttpActionResult Get()
        {
            var result = _goseService.GetRespondentTypes();

            return Ok(result);
        }
    }
}
