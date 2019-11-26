using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Invoices;
using PsychologicalServices.Models.Rights;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/consultingagreementinvoice")]
    public class ConsultingAgreementInvoiceController : ApiController
    {
        private readonly IInvoiceService _invoiceService = null;

        public ConsultingAgreementInvoiceController(
            IInvoiceService invoiceService
        )
        {
            _invoiceService = invoiceService;
        }

        [RightAuthorize(StaticRights.CreateConsultingInvoice)]
        [Route("create")]
        [HttpPost]
        [ResponseType(typeof(Invoice))]
        public IHttpActionResult Create(ConsultingInvoiceCreationParameters parameters)
        {
            var invoice = _invoiceService.CreateConsultingInvoice(parameters);

            return Ok(invoice);
        }
    }
}
