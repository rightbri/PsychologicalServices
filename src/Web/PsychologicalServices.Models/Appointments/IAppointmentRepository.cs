using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Appointments
{
    public interface IAppointmentRepository
    {
        Appointment GetAppointment(int id);

        Appointment GetAppointmentForPsychologistInvoice(int id);

        Appointment NewAppointment(int companyId);

        Appointment NewAppointment(int companyId, DateTime appointmentDate);

        AppointmentStatus GetAppointmentStatus(int id);

        IEnumerable<Appointment> GetAppointmentSequenceSiblings(int appointmentId);

        IEnumerable<Appointment> GetAppointments(AppointmentSearchCriteria criteria);

        IEnumerable<Appointment> GetAppointmentsForPsychometristInvoice(AppointmentSearchCriteria criteria);

        IEnumerable<AppointmentSequence> GetAppointmentSequences(bool? isActive = true);

        IEnumerable<AppointmentStatus> GetAppointmentStatuses(bool? isActive = true);

        AppointmentProtocolResponse GetAppointmentProtocolResponse(int id);

        IEnumerable<AppointmentProtocolResponseValue> GetAppointmentProtocolResponseValues(bool? isActive = true);

        int SaveAppointment(Appointment appointment);

        int SaveAppointmentStatus(AppointmentStatus appointmentStatus);

        int SaveAppointmentProtocolResponse(AppointmentProtocolResponse appointmentProtocolResponse);
    }
}
