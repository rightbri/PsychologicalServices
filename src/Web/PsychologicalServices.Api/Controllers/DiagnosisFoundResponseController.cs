using PsychologicalServices.Models.DiagnosisFoundResponses;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/diagnosisfoundresponse")]
    public class DiagnosisFoundResponseController : ApiController
    {
        private readonly IDiagnosisFoundResponseService _diagnosisFoundResponseService = null;

        public DiagnosisFoundResponseController(
            IDiagnosisFoundResponseService diagnosisFoundResponseService
        )
        {
            _diagnosisFoundResponseService = diagnosisFoundResponseService;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<DiagnosisFoundResponse>))]
        public IHttpActionResult Get()
        {
            var diagnosisFoundResponses = _diagnosisFoundResponseService.GetDiagnosisFoundResponses();

            return Ok(diagnosisFoundResponses);
        }

    }
}
