using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Invoices;
using PsychologicalServices.Models.Rights;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/invoiceablearbitrationdata")]
    public class InvoiceableArbitrationDataController : ApiController
    {
        private readonly IInvoiceService _invoiceService = null;

        public InvoiceableArbitrationDataController(
            IInvoiceService invoiceService
        )
        {
            _invoiceService = invoiceService;
        }

        [RightAuthorize(StaticRights.ViewReport)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<InvoiceableArbitrationData>))]
        public IHttpActionResult Search(InvoiceableArbitrationDataSearchCriteria criteria)
        {
            var data = _invoiceService.GetInvoiceableArbitrationData(criteria);

            return Ok(data);
        }
    }
}
