using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository = null;
        private readonly IAppointmentValidator _appointmentValidator = null;

        public AppointmentService(
            IAppointmentRepository appointmentRepository,
            IAppointmentValidator appointmentValidator
        )
        {
            _appointmentRepository = appointmentRepository;
            _appointmentValidator = appointmentValidator;
        }

        public Appointment GetAppointment(int id)
        {
            var appointment = _appointmentRepository.GetAppointment(id);

            if (null == appointment)
            {
                throw new AppointmentNotFoundException(id);
            }

            return appointment;
        }

        public Appointment GetNewAppointment(int companyId)
        {
            var newAppointment = _appointmentRepository.NewAppointment(companyId);

            return newAppointment;
        }

        public Appointment GetNewAppointment(int assessmentId, int companyId)
        {
            var newAppointment = _appointmentRepository.NewAppointment(assessmentId, companyId);

            return newAppointment;
        }

        public AppointmentStatus GetAppointmentStatus(int id)
        {
            var appointmentStatus = _appointmentRepository.GetAppointmentStatus(id);

            if (null == appointmentStatus)
            {
                throw new AppointmentStatusNotFoundException(id);
            }

            return appointmentStatus;
        }

        public IEnumerable<Appointment> GetAppointments(AppointmentSearchCriteria criteria)
        {
            var appointments = _appointmentRepository.GetAppointments(criteria);
            return appointments;
        }

        public IEnumerable<AppointmentStatus> GetAppointmentStatuses(bool? isActive = true)
        {
            var appointmentStatuses = _appointmentRepository.GetAppointmentStatuses(isActive);

            return appointmentStatuses;
        }

        public SaveResult<Appointment> SaveAppointment(Appointment appointment)
        {
            var result = new SaveResult<Appointment>();

            try
            {
                var validation = _appointmentValidator.Validate(appointment);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _appointmentRepository.SaveAppointment(appointment);

                    result.Item = _appointmentRepository.GetAppointment(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                //TODO: log error
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public SaveResult<AppointmentStatus> SaveAppointmentStatus(AppointmentStatus appointmentStatus)
        {
            var result = new SaveResult<AppointmentStatus>();

            try
            {
                var id = _appointmentRepository.SaveAppointmentStatus(appointmentStatus);

                result.Item = _appointmentRepository.GetAppointmentStatus(id);
                result.IsSaved = true;
            }
            catch (Exception ex)
            {
                //TODO: log error
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
