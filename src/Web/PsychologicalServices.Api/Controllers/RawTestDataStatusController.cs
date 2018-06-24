using PsychologicalServices.Models.RawTestData;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/rawtestdatastatus")]
    public class RawTestDataStatusController : ApiController
    {
        private IRawTestDataService _rawTestDataService = null;

        public RawTestDataStatusController(
            IRawTestDataService rawTestDataService
        )
        {
            _rawTestDataService = rawTestDataService;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<RawTestDataStatus>))]
        public IHttpActionResult Get()
        {
            var rawTestDataStatus = _rawTestDataService.GetRawTestDataStatuses();

            return Ok(rawTestDataStatus);
        }
    }
}
