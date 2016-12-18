using PsychologicalServices.Models.Appointments;
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
    [RoutePrefix("api/appointmentstatus")]
    public class AppointmentStatusController : ApiController
    {
        private IAppointmentService _appointmentService = null;

        public AppointmentStatusController(
            IAppointmentService appointmentService
        )
        {
            _appointmentService = appointmentService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(AppointmentStatus))]
        public IHttpActionResult Get(int id)
        {
            var appointmentStatus = _appointmentService.GetAppointmentStatus(id);

            return Ok(appointmentStatus);
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<AppointmentStatus>))]
        public IHttpActionResult Get()
        {
            var appointmentStatuses = _appointmentService.GetAppointmentStatuses();

            return Ok(appointmentStatuses);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<AppointmentStatus>))]
        public IHttpActionResult Save(AppointmentStatus appointmentStatus)
        {
            var result = _appointmentService.SaveAppointmentStatus(appointmentStatus);

            return Ok(result);
        }
    }
}
