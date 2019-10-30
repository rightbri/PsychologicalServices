using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Invoices;
using PsychologicalServices.Models.Rights;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/invoiceableappointmentdata")]
    public class InvoiceableAppointmentDataController : ApiController
    {
        private readonly IInvoiceService _invoiceService = null;

        public InvoiceableAppointmentDataController(
            IInvoiceService invoiceService
        )
        {
            _invoiceService = invoiceService;
        }

        [RightAuthorize(StaticRights.ViewReport)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<InvoiceableAppointmentData>))]
        public IHttpActionResult Search(InvoiceableAppointmentDataSearchCriteria criteria)
        {
            var data = _invoiceService.GetInvoiceableAppointmentData(criteria);

            return Ok(data);
        }
    }
}
