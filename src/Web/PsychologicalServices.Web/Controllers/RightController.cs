using PsychologicalServices.Models.Rights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
{
    [RoutePrefix("api/right")]
    public class RightController : ApiController
    {
        private readonly IRightService _rightService = null;

        public RightController(
            IRightService rightService
        )
        {
            _rightService = rightService;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<Right>))]
        public IHttpActionResult Get()
        {
            var rights = _rightService.GetRights();

            return Ok(rights);
        }
    }
}
