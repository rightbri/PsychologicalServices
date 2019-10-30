using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Analysis;
using PsychologicalServices.Models.Rights;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/bookingdata")]
    public class BookingDataController : ApiController
    {
        private readonly IAnalysisService _analysisService = null;

        public BookingDataController(
            IAnalysisService analysisService
        )
        {
            _analysisService = analysisService;
        }

        [RightAuthorize(StaticRights.ViewReport)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<BookingData>))]
        public IHttpActionResult Search(BookingDataSearchCriteria criteria)
        {
            var data = _analysisService.GetBookingData(criteria);

            return Ok(data);
        }
    }
}
