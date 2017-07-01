using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Appointments
{
    public interface IAppointmentRepository
    {
        Appointment GetAppointment(int id);

        Appointment NewAppointment(int companyId);

        Appointment NewAppointment(int companyId, DateTime appointmentDate);

        AppointmentStatus GetAppointmentStatus(int id);

        IEnumerable<Appointment> GetAppointments(AppointmentSearchCriteria criteria);

        IEnumerable<AppointmentStatus> GetAppointmentStatuses(bool? isActive = true);

        int SaveAppointment(Appointment appointment);

        int SaveAppointmentStatus(AppointmentStatus appointmentStatus);

        int GetLateCancellationStatusId();
    }
}
