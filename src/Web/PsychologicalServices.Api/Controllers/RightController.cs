using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Rights;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
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

        [RightAuthorize(StaticRights.ViewRight)]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Right>))]
        public IHttpActionResult Get()
        {
            var rights = _rightService.GetRights();

            return Ok(rights);
        }
    }
}
