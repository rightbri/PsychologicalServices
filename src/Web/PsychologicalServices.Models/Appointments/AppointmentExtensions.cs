using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Appointments
{
    public static class AppointmentExtensions
    {
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

        public static bool IsFirstInvoiceableAppointment(this Appointment appointment, IEnumerable<Appointment> appointments)
        {
            var priorAppointments = appointment.PriorAppointments(appointments);

            var billableAppointmentStatuses = new[]
            {
                AppointmentStatus.Incomplete,
                AppointmentStatus.Complete,
                AppointmentStatus.NoShow,
                AppointmentStatus.LateCancellation,
            };

            return
                !priorAppointments.Any(priorAppointment =>
                    billableAppointmentStatuses.Contains(
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
            if (appointment.IsFirst(appointments) || appointment.IsFirstTimeSeen(appointments))
            {
                //first
                return new AppointmentSequence
                {
                    AppointmentSequenceId = Appointments.AppointmentSequence.First,
                    Name = Appointments.AppointmentSequence.GetName(Appointments.AppointmentSequence.First),
                    IsActive = true,
                };
            }
            else if (appointment.AppointmentStatus.IsComplete() && appointment.PriorAppointments(appointments).Any())
            {
                //last
                return new AppointmentSequence
                {
                    AppointmentSequenceId = Appointments.AppointmentSequence.Last,
                    Name = Appointments.AppointmentSequence.GetName(Appointments.AppointmentSequence.Last),
                    IsActive = true,
                };
            }
            else
            {
                //subsequent
                return new AppointmentSequence
                {
                    AppointmentSequenceId = Appointments.AppointmentSequence.Subsequent,
                    Name = Appointments.AppointmentSequence.GetName(Appointments.AppointmentSequence.Subsequent),
                    IsActive = true,
                };
            }
        }

        public static bool IsComplete(this AppointmentStatus appointmentStatus)
        {
            return null != appointmentStatus && appointmentStatus.Name == "Complete";
        }
    }
}
