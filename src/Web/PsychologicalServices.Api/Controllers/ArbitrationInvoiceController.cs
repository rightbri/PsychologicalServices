using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Invoices;
using PsychologicalServices.Models.Rights;
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

        [RightAuthorize(StaticRights.CreateArbitrationInvoice)]
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
