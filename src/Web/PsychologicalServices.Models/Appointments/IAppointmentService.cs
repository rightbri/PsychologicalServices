using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Appointments
{
    public interface IAppointmentService
    {
        Appointment GetAppointment(int id);

        Appointment GetNewAppointment(int companyId);

        AppointmentStatus GetAppointmentStatus(int id);

        AppointmentProtocolResponse GetAppointmentProtocolResponse(int appointmentId);

        IEnumerable<Appointment> GetAppointments(AppointmentSearchCriteria criteria);

        IEnumerable<AppointmentStatus> GetAppointmentStatuses(bool? isActive = true);

        IEnumerable<AppointmentProtocolResponseValue> GetAppointmentProtocolResponseValues(bool? isActive = true);

        SaveResult<Appointment> SaveAppointment(Appointment appointment);

        SaveResult<AppointmentStatus> SaveAppointmentStatus(AppointmentStatus appointmentStatus);

        SaveResult<AppointmentProtocolResponse> SaveAppointmentProtocolResponse(AppointmentProtocolResponse appointmentProtocolResponse);
    }
}
