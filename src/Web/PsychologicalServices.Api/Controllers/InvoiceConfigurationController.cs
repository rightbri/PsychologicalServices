using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Invoices;
using PsychologicalServices.Models.Rights;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/invoiceconfiguration")]
    public class InvoiceConfigurationController : ApiController
    {
        private readonly IInvoiceService _invoiceService = null;

        public InvoiceConfigurationController(
            IInvoiceService invoiceService
        )
        {
            _invoiceService = invoiceService;
        }

        [RightAuthorize(StaticRights.ViewInvoiceConfiguration)]
        [Route("{companyId}")]
        [HttpGet]
        [ResponseType(typeof(InvoiceConfiguration))]
        public IHttpActionResult Get(int companyId)
        {
            var invoiceConfiguration = _invoiceService.GetInvoiceConfiguration(companyId);

            return Ok(invoiceConfiguration);
        }

        [RightAuthorize(StaticRights.EditInvoiceConfiguration)]
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<InvoiceConfiguration>))]
        public IHttpActionResult Save(InvoiceConfiguration invoiceConfiguration)
        {
            var result = _invoiceService.SaveInvoiceConfiguration(invoiceConfiguration);

            return Ok(result);
        }
    }
}
