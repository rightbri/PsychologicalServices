using PsychologicalServices.Models.Reports;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Rights;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/reportstatus")]
    public class ReportStatusController : ApiController
    {
        private readonly IReportService _reportService = null;

        public ReportStatusController(
            IReportService reportService
        )
        {
            _reportService = reportService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(ReportStatus))]
        public IHttpActionResult Get(int id)
        {
            var reportStatus = _reportService.GetReportStatus(id);

            return Ok(reportStatus);
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<ReportStatus>))]
        public IHttpActionResult Get()
        {
            var reportStatuses = _reportService.GetReportStatuses();

            return Ok(reportStatuses);
        }

        [RightAuthorize(StaticRights.EditReportStatus)]
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<ReportStatus>))]
        public IHttpActionResult Save(ReportStatus reportStatus)
        {
            var result = _reportService.SaveReportStatus(reportStatus);

            return Ok(result);
        }
    }
}
