using PsychologicalServices.Web.Infrastructure.Results;
using PsychologicalServices.Models.Invoices;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Collections.Generic;

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
    }
}
