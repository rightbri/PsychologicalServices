using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Invoices;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/invoice")]
    public class InvoiceController : ApiController
    {
        private readonly IInvoiceService _invoiceService = null;

        public InvoiceController(
            IInvoiceService invoiceService
        )
        {
            _invoiceService = invoiceService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Invoice))]
        public IHttpActionResult Get(int id)
        {
            var invoice = _invoiceService.GetInvoice(id);

            return Ok(invoice);
        }

        [Route("refresh")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<InvoiceLineGroup>))]
        public IHttpActionResult Refresh(Invoice invoice)
        {
            var invoiceLineGroups = _invoiceService.GetInvoiceLineGroups(invoice);

            return Ok(invoiceLineGroups);
        }

        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<Invoice>))]
        public IHttpActionResult Search(InvoiceSearchCriteria criteria)
        {
            var invoices = _invoiceService.GetInvoices(criteria);

            return Ok(invoices);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<Invoice>))]
        public IHttpActionResult Save(Invoice invoice)
        {
            var result = _invoiceService.SaveInvoice(invoice);

            return Ok(result);
        }
    }
}
