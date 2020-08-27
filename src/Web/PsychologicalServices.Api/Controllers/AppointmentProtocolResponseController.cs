using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Rights;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
{
    [RoutePrefix("api/appointmentprotocolresponse")]
    public class AppointmentProtocolResponseController : ApiController
    {
        private IAppointmentService _appointmentService = null;

        public AppointmentProtocolResponseController(
            IAppointmentService appointmentService
        )
        {
            _appointmentService = appointmentService;
        }

        [RightAuthorize(StaticRights.ViewAppointmentProtocolResponse)]
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(AppointmentProtocolResponse))]
        public IHttpActionResult Get(int id)
        {
            var appointmentProtocolResponse = _appointmentService.GetAppointmentProtocolResponse(id);

            return Ok(appointmentProtocolResponse);
        }

        [RightAuthorize(StaticRights.EditAppointmentProtocolResponse)]
        [Route("save")]
        [HttpPut]
        [ResponseType(typeof(SaveResult<AppointmentProtocolResponse>))]
        public IHttpActionResult Save(AppointmentProtocolResponse appointmentProtocolResponse)
        {
            var result = _appointmentService.SaveAppointmentProtocolResponse(appointmentProtocolResponse);

            return Ok(result);
        }
    }
}
