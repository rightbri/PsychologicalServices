using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Web.Controllers
{
    [RoutePrefix("api/taskStatus")]
    public class TaskStatusController : ApiController
    {
        private readonly ITaskService _taskService = null;

        public TaskStatusController(
            ITaskService taskService
        )
        {
            _taskService = taskService;
        }

        //[Route("{id}")]
        //[HttpGet]
        //[ResponseType(typeof(TaskStatus))]
        //public IHttpActionResult Get(int id)
        //{
        //    var taskStatus = _taskService.GetTaskStatus(id);

        //    return Ok(taskStatus);
        //}

        [HttpGet]
        [ResponseType(typeof(IEnumerable<TaskStatus>))]
        public IHttpActionResult Get()
        {
            var taskStatuses = _taskService.GetTaskStatuses(true);

            return Ok(taskStatuses);
        }

        //[Route("save")]
        //[HttpPut]
        //[ResponseType(typeof(SaveResult<Company>))]
        //public IHttpActionResult Save(Company company)
        //{
        //    var result = _companyService.SaveCompany(company);

        //    return Ok(result);
        //}
    }
}
