using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Employers;
using PsychologicalServices.Models.Rights;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/employer")]
    public class EmployerController : ApiController
    {
        private readonly IEmployerService _employerService = null;

        public EmployerController(
            IEmployerService employerService
        )
        {
            _employerService = employerService;
        }

        [RightAuthorize(StaticRights.SearchEmployer)]
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Employer))]
        public IHttpActionResult Get(int id)
        {
            var employer = _employerService.GetEmployer(id);

            return Ok(employer);
        }

        [RightAuthorize(StaticRights.SearchEmployer)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<Employer>))]
        public IHttpActionResult Post(EmployerSearchCriteria criteria)
        {
            var employers = _employerService.GetEmployers(criteria);

            return Ok(employers);
        }

        [RightAuthorize(StaticRights.EditEmployer)]
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<Employer>))]
        public IHttpActionResult Save(Employer employer)
        {
            var result = _employerService.SaveEmployer(employer);

            return Ok(result);
        }
    }
}
