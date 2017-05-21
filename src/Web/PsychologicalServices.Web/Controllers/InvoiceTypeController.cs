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
    [RoutePrefix("api/invoicetype")]
    public class InvoiceTypeController : ApiController
    {
        private readonly IInvoiceService _invoiceService = null;

        public InvoiceTypeController(
            IInvoiceService invoiceService
        )
        {
            _invoiceService = invoiceService;
        }
        
        [HttpGet]
        [ResponseType(typeof(IEnumerable<InvoiceType>))]
        public IHttpActionResult Get()
        {
            var invoiceTypes = _invoiceService.GetInvoiceTypes();

            return Ok(invoiceTypes);
        }
    }
}
