using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
{
    [RoutePrefix("api/assessment")]
    public class AssessmentController : ApiController
    {
        private IAssessmentService _assessmentService = null;

        public AssessmentController(
            IAssessmentService assessmentService
        )
        {
            _assessmentService = assessmentService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Assessment))]
        public IHttpActionResult Get(int id)
        {
            var assessment = _assessmentService.GetAssessment(id);

            return Ok(assessment);
        }

        [Route("company/{companyId}/appointment/{year}/{month}/{day}")]
        [HttpGet]
        [ResponseType(typeof(Assessment))]
        public IHttpActionResult GetNewAssessment(int companyId, int year, int month, int day)
        {
            var assessment = _assessmentService.GetNewAssessment(companyId, new DateTime(year, month, day));
            
            return Ok(assessment);
        }


        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<Assessment>))]
        public IHttpActionResult Search(AssessmentSearchCriteria criteria)
        {
            var assessments = _assessmentService.SearchAssessments(criteria);

            return Ok(assessments);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<Assessment>))]
        public IHttpActionResult Save(Assessment assessment)
        {
            var result = _assessmentService.SaveAssessment(assessment);

            return Ok(result);
        }
    }
}
