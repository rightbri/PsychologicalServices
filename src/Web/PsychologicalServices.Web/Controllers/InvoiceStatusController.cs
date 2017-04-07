using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
{
    [RoutePrefix("api/invoicestatus")]
    public class InvoiceStatusController : ApiController
    {
        private readonly IInvoiceService _invoiceService = null;

        public InvoiceStatusController(
            IInvoiceService invoiceService
        )
        {
            _invoiceService = invoiceService;
        }
        
        [HttpGet]
        [ResponseType(typeof(IEnumerable<InvoiceStatus>))]
        public IHttpActionResult Get()
        {
            var invoiceStatuses = _invoiceService.GetInvoiceStatuses();

            return Ok(invoiceStatuses);
        }
    }
}
