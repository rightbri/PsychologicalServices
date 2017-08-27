using PsychologicalServices.Models.Outstanding;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
{
    [RoutePrefix("api/outstandingreport")]
    public class OutstandingReportController : ApiController
    {
        private readonly IOutstandingService _outstandingService = null;

        public OutstandingReportController(
            IOutstandingService outstandingService
        )
        {
            _outstandingService = outstandingService;
        }
        
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<OutstandingReport>))]
        public IHttpActionResult Search(OutstandingReportSearchCriteria criteria)
        {
            var data = _outstandingService.GetOutstandingReports(criteria);

            return Ok(data);
        }
    }
}
