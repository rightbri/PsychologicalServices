using PsychologicalServices.Api.Infrastructure.Results;
using PsychologicalServices.Models.Invoices;
using System;
using System.Web.Http;
using System.Web.Http.Description;
using System.Collections.Generic;

namespace PsychologicalServices.Api.Controllers
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
        [ResponseType(typeof(BinaryFileResult))]
        public IHttpActionResult GetDocument(int id)
        {
            var invoiceDocument = _invoiceService.GetInvoiceDocument(id);

            return new BinaryFileResult(invoiceDocument.Content, invoiceDocument.FileName);
        }

        [Route("invoice/{id}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<InvoiceDocument>))]
        public IHttpActionResult GetDocuments(int id)
        {
            var invoiceDocuments = _invoiceService.GetInvoiceDocuments(id);

            return Ok(invoiceDocuments);
        }

        [Route("send")]
        [HttpPost]
        [ResponseType(typeof(InvoiceSendResult))]
        public IHttpActionResult Send(InvoiceSendParameters parameters)
        {
            var sendResult = _invoiceService.SendInvoiceDocument(parameters);

            return Ok(sendResult);
        }
    }
}
