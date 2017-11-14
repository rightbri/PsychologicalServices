using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Employers;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/employertype")]
    public class EmployerTypeController : ApiController
    {
        private readonly IEmployerService _employerService = null;

        public EmployerTypeController(
            IEmployerService employerService
        )
        {
            _employerService = employerService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(EmployerType))]
        public IHttpActionResult Get(int id)
        {
            var employerType = _employerService.GetEmployerType(id);

            return Ok(employerType);
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<EmployerType>))]
        public IHttpActionResult Get()
        {
            var employerTypes = _employerService.GetEmployerTypes();

            return Ok(employerTypes);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<EmployerType>))]
        public IHttpActionResult Save(EmployerType employerType)
        {
            var result = _employerService.SaveEmployerType(employerType);

            return Ok(result);
        }
    }
}
