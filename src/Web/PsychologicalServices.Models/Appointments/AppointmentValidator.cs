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
            if (null == item)
            {
                throw new ArgumentNullException("item");
            }

            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (null == item.Location)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "LocationId", Message = GetValidationMessage(item, "Please select a location") }
                );
            }
            else
            {
                var location = _addressRepository.GetAddress(item.Location.AddressId);

                if (null == location)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "LocationId", Message = GetValidationMessage(item, "Invalid location") }
                    );
                }
            }
            
            if (null == item.Psychometrist)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "Psychometrist", Message = GetValidationMessage(item, "Please select a psychometrist") }
                );
            }
            else
            {
                var psychometrist = _userRepository.GetUserById(item.Psychometrist.UserId);

                if (null == psychometrist)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "PsychometristId", Message = GetValidationMessage(item, "Invalid psychometrist") }
                    );
                }
                else if (!psychometrist.HasRight(StaticRights.Psychometrist))
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "PsychometristId", Message = GetValidationMessage(item, "The selected user is not a psychometrist") }
                    );
                }
                else if (!psychometrist.IsActive)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "PsychometristId", Message = GetValidationMessage(item, "The selected psychometrist is not active") }
                    );
                }
            }
            
            if (null == item.Psychologist)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "PsychologistId", Message = GetValidationMessage(item, "Please select a psychologist") }
                );
            }
            else
            {
                var psychologist = _userRepository.GetUserById(item.Psychologist.UserId);

                if (null == psychologist)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "PsychologistId", Message = GetValidationMessage(item, "Invalid psychologistId") }
                    );
                }
                else if (!psychologist.HasRight(StaticRights.Psychologist))
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "PsychologistId", Message = GetValidationMessage(item, "The selected user is not a psychologistId") }
                    );
                }
                else if (!psychologist.IsActive)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "PsychologistId", Message = GetValidationMessage(item, "The selected psychologistId is not active") }
                    );
                }
            }
            
            if (null == item.AppointmentStatus)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "AppointmentStatusId", Message = GetValidationMessage(item, "Please select an appointment status") }
                );
            }
            else
            {
                var appointmentStatus = _appointmentRepository.GetAppointmentStatus(item.AppointmentStatus.AppointmentStatusId);

                if (null == appointmentStatus)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "AppointmentStatusId", Message = GetValidationMessage(item, "Invalid appointment status") }
                    );
                }
            }

            if (item.AppointmentTime == DateTime.MinValue)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "AppointmentTime", Message = GetValidationMessage(item, "Please select an appointment time") }
                );
            }
            
            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }

        private string GetValidationMessage(Appointment item, string message)
        {
            return string.Format("{0}{1}", GetMessagePrefix(item), message);
        }

        private string GetMessagePrefix(Appointment item)
        {
            return string.Format("Appointment on {0:MMMM d, yyyy}: ", item.AppointmentTime);
        }
    }
}
