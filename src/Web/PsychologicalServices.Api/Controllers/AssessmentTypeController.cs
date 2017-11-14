using PsychologicalServices.Models.Assessments;
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
    [RoutePrefix("api/assessmenttype")]
    public class AssessmentTypeController : ApiController
    {
        private IAssessmentService _assessmentService = null;

        public AssessmentTypeController(
            IAssessmentService assessmentService
        )
        {
            _assessmentService = assessmentService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(AssessmentType))]
        public IHttpActionResult Get(int id)
        {
            var assessmentType = _assessmentService.GetAssessmentType(id);

            return Ok(assessmentType);
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<AssessmentType>))]
        public IHttpActionResult Get()
        {
            var assessmentTypes = _assessmentService.GetAssessmentTypes();

            return Ok(assessmentTypes);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<AssessmentType>))]
        public IHttpActionResult Save(AssessmentType assessmentType)
        {
            var result = _assessmentService.SaveAssessmentType(assessmentType);

            return Ok(result);
        }
    }
}
