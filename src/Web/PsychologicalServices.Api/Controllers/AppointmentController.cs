﻿using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Rights;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PsychologicalServices.Api.Controllers
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

        [RightAuthorize(StaticRights.ViewAppointment)]
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult Get(int id)
        {
            var appointment = _appointmentService.GetAppointment(id);

            return Ok(appointment);
        }

        [Route("company/{companyId}")]
        [HttpGet]
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult GetNewAppointment(int companyId)
        {
            var appointment = _appointmentService.GetNewAppointment(companyId);

            return Ok(appointment);
        }

        [RightAuthorize(StaticRights.SearchAppointment)]
        [Route("search")]
        [HttpPost]
        [ResponseType(typeof(IEnumerable<Appointment>))]
        public IHttpActionResult Search(AppointmentSearchCriteria criteria)
        {
            var appointments = _appointmentService.GetAppointments(criteria);

            return Ok(appointments);
        }

        [RightAuthorize(StaticRights.EditAppointment)]
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
