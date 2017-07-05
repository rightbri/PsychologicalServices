using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Appointments
{
    public static class AppointmentExtensions
    {
        public static bool IsCompletion(this Appointment appointment, IEnumerable<Appointment> appointments)
        {
            return
                null != appointment &&
                null != appointments &&
                appointments.Any(appt =>
                    appt.Assessment.AssessmentId == appointment.Assessment.AssessmentId &&
                    appt.AppointmentStatus.AppointmentStatusId == AppointmentStatus.Incomplete &&
                    appt.AppointmentTime < appointment.AppointmentTime
                );
        }

        public static bool IsFirst(this Appointment appointment, IEnumerable<Appointment> appointments)
        {
            return !appointment.PriorAppointments(appointments).Any();
        }

        public static bool IsFirstTimeSeen(this Appointment appointment, IEnumerable<Appointment> appointments)
        {
            var priorAppointments = appointment.PriorAppointments(appointments);

            var claimantSeenAppointmentStatuses = new[]
            {
                AppointmentStatus.Showed,
                AppointmentStatus.Incomplete,
                AppointmentStatus.Complete
            };

            return
                !priorAppointments.Any(priorAppointment =>
                    claimantSeenAppointmentStatuses.Contains(
                        priorAppointment.AppointmentStatus.AppointmentStatusId
                    )
                );
        }

        public static IEnumerable<Appointment> PriorAppointments(this Appointment appointment, IEnumerable<Appointment> appointments)
        {
            return appointments
                .Where(appt =>
                    appt.Assessment.AssessmentId == appointment.Assessment.AssessmentId &&
                    appt.AppointmentTime < appointment.AppointmentTime
                );
        }

        public static AppointmentSequence AppointmentSequence(this Appointment appointment, IEnumerable<Appointment> appointments)
        {
            var appointmentSequenceId = (
                        appointment.IsFirst(appointments) ||
                        appointment.IsFirstTimeSeen(appointments)
                    )
                    ? Appointments.AppointmentSequence.First
                    : Appointments.AppointmentSequence.Subsequent;

            var appointmentSequence = new AppointmentSequence
            {
                AppointmentSequenceId = appointmentSequenceId,
                Name = appointmentSequenceId == Appointments.AppointmentSequence.First
                    ? "First"
                    : "Subsequent",
                IsActive = true,
            };

            return appointmentSequence;
        }
    }
}
