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

            var location = _addressRepository.GetAddress(item.LocationId);

            if (null == location)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "LocationId", Message = "Invalid location" }
                );
            }

            var psychometrist = _userRepository.GetUserById(item.PsychometristId);

            if (null == psychometrist)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "PsychometristId", Message = "Invalid psychometrist" }
                );
            }
            else if (!psychometrist.HasRight(StaticRights.Psychometrist))
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "PsychometristId", Message = "The selected user is not a psychometrist" }
                );
            }
            else if (!psychometrist.IsActive)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "PsychometristId", Message = "The selected psychometrist is not active" }
                );
            }

            var psychologist = _userRepository.GetUserById(item.PsychologistId);

            if (null == psychologist)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "PsychologistId", Message = "Invalid psychologistId" }
                );
            }
            else if (!psychologist.HasRight(StaticRights.Psychologist))
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "PsychologistId", Message = "The selected user is not a psychologistId" }
                );
            }
            else if (!psychologist.IsActive)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "PsychologistId", Message = "The selected psychologistId is not active" }
                );
            }

            //var psychometrists = _userRepository.GetUsers(new UserSearchCriteria
            //    {
            //        UserId = item.PsychometristId,
            //        RightId = (int)StaticRights.Psychometrist,
            //        CompanyId = item.CompanyId,
            //    });

            //if (!psychometrists.Any())
            //{
            //    result.ValidationErrors.Add(
            //        new ValidationError { Property = "PsychometristId", Message = "Invalid psychometrist" }
            //    );
            //}
            //else if (!psychometrists.First().IsActive)
            //{
            //    result.ValidationErrors.Add(
            //        new ValidationError { Property = "PsychometristId", Message = "The selected psychometrist is not active" }
            //    );
            //}

            //var psychologists = _userRepository.GetUsers(new UserSearchCriteria
            //    {
            //        UserId = item.PsychologistId,
            //        RightId = (int)StaticRights.Psychologist,
            //        CompanyId = item.CompanyId,
            //    });

            //if (!psychologists.Any())
            //{
            //    result.ValidationErrors.Add(
            //        new ValidationError { Property = "PsychologistId", Message = "Invalid psychologist" }
            //    );
            //}
            //else if (!psychologists.First().IsActive)
            //{
            //    result.ValidationErrors.Add(
            //        new ValidationError { Property = "PsychologistId", Message = "The selected psychologist is not active" }
            //    );
            //}

            var appointmentStatus = _appointmentRepository.GetAppointmentStatus(item.AppointmentStatusId);

            if (null == appointmentStatus)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "AppointmentStatusId", Message = "Invalid appointment status" }
                );
            }

            //DateTime AppointmentTime

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
