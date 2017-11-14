using PsychologicalServices.Models.Reports;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/reporttype")]
    public class ReportTypeController : ApiController
    {
        private readonly IReportService _reportService = null;

        public ReportTypeController(
            IReportService reportService
        )
        {
            _reportService = reportService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(ReportType))]
        public IHttpActionResult Get(int id)
        {
            var reportType = _reportService.GetReportType(id);

            return Ok(reportType);
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<ReportType>))]
        public IHttpActionResult Get()
        {
            var reportTypes = _reportService.GetReportTypes();

            return Ok(reportTypes);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<ReportType>))]
        public IHttpActionResult Save(ReportType reportType)
        {
            var result = _reportService.SaveReportType(reportType);

            return Ok(result);
        }
    }
}
