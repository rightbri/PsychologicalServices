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
    [RoutePrefix("api/appointment")]
    public class AppointmentController : ApiController
    {
        private IAppointmentService _appointmentService = null;

        public AppointmentController(
            IAppointmentService appointmentService
        )
        {
            _appointmentService = appointmentService;
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult Get(int id)
        {
            var appointment = _appointmentService.GetAppointment(id);

            return Ok(appointment);
        }

        [Route("company/{companyId}/assessment/{assessmentId}")]
        [HttpGet]
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult Get(int assessmentId, int companyId)
        {
            var appointment = _appointmentService.GetNewAppointment(assessmentId, companyId);

            return Ok(appointment);
        }

        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<Appointment>))]
        public IHttpActionResult Search(AppointmentSearchCriteria criteria)
        {
            var appointments = _appointmentService.GetAppointments(criteria);

            return Ok(appointments);
        }

        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<Appointment>))]
        public IHttpActionResult Save(Appointment appointment)
        {
            var result = _appointmentService.SaveAppointment(appointment);

            return Ok(result);
        }
    }
}
