using PsychologicalServices.Models.Invoices;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/rawtestdatainvoice")]
    public class RawTestDataInvoiceController : ApiController
    {
        private readonly IInvoiceService _invoiceService = null;

        public RawTestDataInvoiceController(
            IInvoiceService invoiceService
        )
        {
            _invoiceService = invoiceService;
        }

        [Route("create")]
        [HttpPost]
        [ResponseType(typeof(Invoice))]
        public IHttpActionResult Create(RawTestDataInvoiceCreationParameters parameters)
        {
            var invoice = _invoiceService.CreateRawTestDataInvoice(parameters);

            return Ok(invoice);
        }
    }
}
