using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Arbitrations;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Rights;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/arbitration")]
    public class ArbitrationController : ApiController
    {
        private IArbitrationService _arbitrationService = null;

        public ArbitrationController(
            IArbitrationService arbitrationService
        )
        {
            _arbitrationService = arbitrationService;
        }

        [RightAuthorize(StaticRights.ViewArbitration)]
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Arbitration))]
        public IHttpActionResult Get(int id)
        {
            var arbitration = _arbitrationService.GetArbitration(id);

            return Ok(arbitration);
        }

        [RightAuthorize(StaticRights.SearchArbitration)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<Arbitration>))]
        public IHttpActionResult Search(ArbitrationSearchCriteria criteria)
        {
            var arbitrations = _arbitrationService.GetArbitrations(criteria);

            return Ok(arbitrations);
        }

        [RightAuthorize(StaticRights.EditArbitration)]
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<Arbitration>))]
        public IHttpActionResult Save(Arbitration arbitration)
        {
            var result = _arbitrationService.SaveArbitration(arbitration);

            return Ok(result);
        }
    }
}
