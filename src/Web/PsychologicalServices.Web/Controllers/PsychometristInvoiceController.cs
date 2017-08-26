using PsychologicalServices.Models.Invoices;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
{
    [RoutePrefix("api/psychometristinvoice")]
    public class PsychometristInvoiceController : ApiController
    {
        private readonly IInvoiceService _invoiceService = null;

        public PsychometristInvoiceController(
            IInvoiceService invoiceService
        )
        {
            _invoiceService = invoiceService;
        }

        [Route("create")]
        [HttpPost]
        [ResponseType(typeof(Invoice))]
        public IHttpActionResult Create(PsychometristInvoiceCreationParameters parameters)
        {
            var invoice = _invoiceService.CreatePsychometristInvoice(parameters);

            return Ok(invoice);
        }
    }
}
