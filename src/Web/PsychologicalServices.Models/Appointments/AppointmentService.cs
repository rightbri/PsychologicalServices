using log4net;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository = null;
        private readonly IAppointmentValidator _appointmentValidator = null;
        private readonly ILog _log = null;

        public AppointmentService(
            IAppointmentRepository appointmentRepository,
            IAppointmentValidator appointmentValidator,
            ILog log
        )
        {
            _appointmentRepository = appointmentRepository;
            _appointmentValidator = appointmentValidator;
            _log = log;
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

        public AppointmentStatus GetAppointmentStatus(int id)
        {
            var appointmentStatus = _appointmentRepository.GetAppointmentStatus(id);

            if (null == appointmentStatus)
            {
                throw new AppointmentStatusNotFoundException(id);
            }

            return appointmentStatus;
        }

        public AppointmentProtocolResponse GetAppointmentProtocolResponse(int appointmentId)
        {
            var item = _appointmentRepository.GetAppointmentProtocolResponse(appointmentId);

            if (null == item)
            {
                throw new ArgumentOutOfRangeException(nameof(appointmentId));
            }

            return item;
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

        public IEnumerable<AppointmentProtocolResponseValue> GetAppointmentProtocolResponseValues(bool? isActive = true)
        {
            var items = _appointmentRepository.GetAppointmentProtocolResponseValues(isActive);

            return items;
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
                    //TODO: notify on appointment status changes

                    var id = _appointmentRepository.SaveAppointment(appointment);

                    result.Item = _appointmentRepository.GetAppointment(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveAppointment", ex);
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
                _log.Error("SaveAppointmentStatus", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public SaveResult<AppointmentProtocolResponse> SaveAppointmentProtocolResponse(AppointmentProtocolResponse appointmentProtocolResponse)
        {
            var result = new SaveResult<AppointmentProtocolResponse>();

            try
            {
                var id = _appointmentRepository.SaveAppointmentProtocolResponse(appointmentProtocolResponse);

                result.Item = _appointmentRepository.GetAppointmentProtocolResponse(id);
                result.IsSaved = true;
            }
            catch (Exception ex)
            {
                _log.Error("SaveAppointmentProtocolResponse", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
