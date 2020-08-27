using PsychologicalServices.Models.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/appointmentprotocolresponsevalue")]
    public class AppointmentProtocolResponseValueController : ApiController
    {
        private IAppointmentService _appointmentService = null;

        public AppointmentProtocolResponseValueController(
            IAppointmentService appointmentService
        )
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<AppointmentProtocolResponseValue>))]
        public IHttpActionResult Get()
        {
            var items = _appointmentService.GetAppointmentProtocolResponseValues();

            return Ok(items);
        }
    }
}
