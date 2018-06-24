using PsychologicalServices.Models.Invoices;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/invoiceablerawtestdata")]
    public class InvoiceableRawTestDataController : ApiController
    {
        private readonly IInvoiceService _invoiceService = null;

        public InvoiceableRawTestDataController(
            IInvoiceService invoiceService
        )
        {
            _invoiceService = invoiceService;
        }
        
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<InvoiceableRawTestDataData>))]
        public IHttpActionResult Search(InvoiceableRawTestDataSearchCriteria criteria)
        {
            var data = _invoiceService.GetInvoiceableRawTestDataData(criteria);

            return Ok(data);
        }
    }
}
