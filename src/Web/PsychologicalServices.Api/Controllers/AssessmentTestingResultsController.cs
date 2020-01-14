using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Rights;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/assessmenttestingresults")]
    public class AssessmentTestingResultsController : ApiController
    {
        private IAssessmentService _assessmentService = null;

        public AssessmentTestingResultsController(
            IAssessmentService assessmentService
        )
        {
            _assessmentService = assessmentService;
        }

        [RightAuthorize(StaticRights.ViewAssessmentNote)]
        [Route("{assessmentId}/{name}")]
        [HttpGet]
        [ResponseType(typeof(Assessment))]
        public IHttpActionResult Get(int assessmentId, string name)
        {
            var testingResults = _assessmentService.GetAssessmentTestingResults(assessmentId, name);

            return Ok(testingResults);
        }

        [RightAuthorize(StaticRights.EditAssessmentNote)]
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<AssessmentTestingResults>))]
        public IHttpActionResult Save(AssessmentTestingResults testingResults)
        {
            var result = _assessmentService.SaveAssessmentTestingResults(testingResults);

            return Ok(result);
        }

        [RightAuthorize(StaticRights.DeleteAssessmentNote)]
        [Route("{assessmentId}/{name}")]
        [HttpDelete]
        [ResponseType(typeof(DeleteResult))]
        public IHttpActionResult Delete(int assessmentId, string name)
        {
            var result = _assessmentService.DeleteAssessmentTestingResults(assessmentId, name);

            return Ok(result);
        }
    }
}
