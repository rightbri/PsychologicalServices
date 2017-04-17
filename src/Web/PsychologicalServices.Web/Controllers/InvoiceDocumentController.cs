using PsychologicalServices.Web.Infrastructure.Results;
using PsychologicalServices.Models.Invoices;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
{
    [RoutePrefix("api/invoicedocument")]
    public class InvoiceDocumentController : ApiController
    {
        private readonly IInvoiceService _invoiceService = null;

        public InvoiceDocumentController(
            IInvoiceService invoiceService
        )
        {
            _invoiceService = invoiceService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(InvoiceDocument))]
        public IHttpActionResult Get(int id)
        {
            var invoice = _invoiceService.GetInvoiceDocument(id);

            return new BinaryFileResult(invoice.Content, invoice.FileName);
        }
    }
}
