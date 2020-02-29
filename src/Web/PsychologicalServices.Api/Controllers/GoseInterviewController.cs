using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Gose;
using PsychologicalServices.Models.Rights;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/goseinterview")]
    public class GoseInterviewController : ApiController
    {
        private IGoseService _goseService = null;

        public GoseInterviewController(
            IGoseService goseService
        )
        {
            _goseService = goseService;
        }

        [RightAuthorize(StaticRights.ViewGoseInterview)]
        [Route("{assessmentId}")]
        [HttpGet]
        [ResponseType(typeof(GoseInterview))]
        public IHttpActionResult Get(int assessmentId)
        {
            var result = _goseService.GetInterview(assessmentId);

            return Ok(result);
        }

        [RightAuthorize(StaticRights.EditGoseInterview)]
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<GoseInterview>))]
        public IHttpActionResult Save(GoseInterview interview)
        {
            var result = _goseService.SaveInterview(interview);

            return Ok(result);
        }

        [RightAuthorize(StaticRights.DeleteGoseInterview)]
        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(DeleteResult))]
        public IHttpActionResult Delete([FromUri]int id)
        {
            var result = _goseService.DeleteInterview(id);

            return Ok(result);
        }
    }
}
