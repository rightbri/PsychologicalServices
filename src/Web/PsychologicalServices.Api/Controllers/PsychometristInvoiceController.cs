using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Invoices;
using PsychologicalServices.Models.Rights;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
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

        [RightAuthorize(StaticRights.CreatePsychometristInvoice)]
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
