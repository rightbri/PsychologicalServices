using PsychologicalServices.Models.Addresses;
using PsychologicalServices.Models.Common.Validation;
using PsychologicalServices.Models.Rights;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Appointments
{
    public class AppointmentValidator : IAppointmentValidator
    {
        private readonly IAppointmentRepository _appointmentRepository = null;
        private readonly IAddressRepository _addressRepository = null;
        private readonly IUserRepository _userRepository = null;
        
        public AppointmentValidator(
            IAppointmentRepository appointmentRepository,
            IAddressRepository addressRepository,
            IUserRepository userRepository
        )
        {
            _appointmentRepository = appointmentRepository;
            _addressRepository = addressRepository;
            _userRepository = userRepository;
        }

        public IValidationResult Validate(Appointment item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            var location = _addressRepository.GetAddress(item.Location.AddressId);

            if (null == location)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "LocationId", Message = "Invalid location" }
                );
            }

            var psychometrist = _userRepository.GetUserById(item.Psychometrist.UserId);

            if (null == psychometrist)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "PsychometristId", Message = "Invalid psychometrist" }
                );
            }
            else if (!psychometrist.HasRight(StaticRights.Psychometrist))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "PsychometristId", Message = "The selected user is not a psychometrist" }
                );
            }
            else if (!psychometrist.IsActive)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "PsychometristId", Message = "The selected psychometrist is not active" }
                );
            }

            var psychologist = _userRepository.GetUserById(item.Psychologist.UserId);

            if (null == psychologist)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "PsychologistId", Message = "Invalid psychologistId" }
                );
            }
            else if (!psychologist.HasRight(StaticRights.Psychologist))
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "PsychologistId", Message = "The selected user is not a psychologistId" }
                );
            }
            else if (!psychologist.IsActive)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "PsychologistId", Message = "The selected psychologistId is not active" }
                );
            }
            
            var appointmentStatus = _appointmentRepository.GetAppointmentStatus(item.AppointmentStatus.AppointmentStatusId);

            if (null == appointmentStatus)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "AppointmentStatusId", Message = "Invalid appointment status" }
                );
            }

            //DateTime AppointmentTime

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
