using PsychologicalServices.Models.Invoices;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/arbitrationinvoice")]
    public class ArbitrationInvoiceController : ApiController
    {
        private readonly IInvoiceService _invoiceService = null;

        public ArbitrationInvoiceController(
            IInvoiceService invoiceService
        )
        {
            _invoiceService = invoiceService;
        }

        [Route("create")]
        [HttpPost]
        [ResponseType(typeof(Invoice))]
        public IHttpActionResult Create(ArbitrationInvoiceCreationParameters parameters)
        {
            var invoice = _invoiceService.CreateArbitrationInvoice(parameters);

            return Ok(invoice);
        }
    }
}
