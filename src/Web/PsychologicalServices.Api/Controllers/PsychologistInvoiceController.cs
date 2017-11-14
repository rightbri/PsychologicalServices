using PsychologicalServices.Models.Invoices;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/psychologistinvoice")]
    public class PsychologistInvoiceController : ApiController
    {
        private readonly IInvoiceService _invoiceService = null;

        public PsychologistInvoiceController(
            IInvoiceService invoiceService
        )
        {
            _invoiceService = invoiceService;
        }

        [Route("create")]
        [HttpPost]
        [ResponseType(typeof(Invoice))]
        public IHttpActionResult Create(PsychologistInvoiceCreationParameters parameters)
        {
            var invoice = _invoiceService.CreatePsychologistInvoice(parameters.AppointmentId);

            return Ok(invoice);
        }
        
        [Route("send")]
        [HttpPost]
        [ResponseType(typeof(PsychologistInvoiceSendResult))]
        public IHttpActionResult Send(PsychologistInvoiceSendParameters parameters)
        {
            var sendResult = _invoiceService.SendPsychologistInvoiceDocument(parameters);

            return Ok(sendResult);
        }
    }
}
