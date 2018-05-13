using PsychologicalServices.Models.Arbitrations;
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
    [RoutePrefix("api/arbitrationstatus")]
    public class ArbitrationStatusController : ApiController
    {
        private IArbitrationService _arbitrationService = null;

        public ArbitrationStatusController(
            IArbitrationService arbitrationService
        )
        {
            _arbitrationService = arbitrationService;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<ArbitrationStatus>))]
        public IHttpActionResult Get()
        {
            var arbitrationStatuses = _arbitrationService.GetArbitrationStatuses();

            return Ok(arbitrationStatuses);
        }
    }
}
