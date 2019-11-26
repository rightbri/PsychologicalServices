using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Invoices;
using PsychologicalServices.Models.Rights;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/invoiceableconsultingagreementdata")]
    public class InvoiceableConsultingAgreementDataController : ApiController
    {
        private readonly IInvoiceService _invoiceService = null;

        public InvoiceableConsultingAgreementDataController(
            IInvoiceService invoiceService
        )
        {
            _invoiceService = invoiceService;
        }

        [RightAuthorize(StaticRights.ViewReport)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<InvoiceableConsultingAgreementData>))]
        public IHttpActionResult Search(InvoiceableConsultingAgreementSearchCriteria criteria)
        {
            var data = _invoiceService.GetInvoiceableConsultingAgreementData(criteria);

            return Ok(data);
        }
    }
}
