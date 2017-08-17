using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Employers;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
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

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Employer))]
        public IHttpActionResult Get(int id)
        {
            var employer = _employerService.GetEmployer(id);

            return Ok(employer);
        }

        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<Employer>))]
        public IHttpActionResult Post(EmployerSearchCriteria criteria)
        {
            var employers = _employerService.GetEmployers(criteria);

            return Ok(employers);
        }

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
