using System;
using System.Collections.Generic;
using PsychologicalServices.Models.Common;
using log4net;

namespace PsychologicalServices.Models.Employers
{
    public class EmployerService : IEmployerService
    {
        private readonly IEmployerRepository _employerRepository = null;
        private readonly IEmployerValidator _employerValidator = null;
        private readonly IEmployerTypeValidator _employerTypeValidator = null;
        private readonly ILog _log = null;

        public EmployerService(
            IEmployerRepository employerRepository,
            IEmployerValidator employerValidator,
            IEmployerTypeValidator employerTypeValidator,
            ILog log
        )
        {
            _employerRepository = employerRepository;
            _employerValidator = employerValidator;
            _employerTypeValidator = employerTypeValidator;
            _log = log;
        }

        public Employer GetEmployer(int id)
        {
            var employer = _employerRepository.GetEmployer(id);

            return employer;
        }

        public EmployerType GetEmployerType(int id)
        {
            var employerType = _employerRepository.GetEmployerType(id);

            return employerType;
        }

        public IEnumerable<Employer> GetEmployers(EmployerSearchCriteria criteria)
        {
            var employers = _employerRepository.GetEmployers(criteria);

            return employers;
        }

        public IEnumerable<EmployerType> GetEmployerTypes(bool? isActive = true)
        {
            var employerTypes = _employerRepository.GetEmployerTypes(isActive);

            return employerTypes;
        }

        public SaveResult<Employer> SaveEmployer(Employer employer)
        {
            var result = new SaveResult<Employer>();

            try
            {
                var validation = _employerValidator.Validate(employer);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _employerRepository.SaveEmployer(employer);

                    result.Item = _employerRepository.GetEmployer(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveEmployer", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public SaveResult<EmployerType> SaveEmployerType(EmployerType employerType)
        {
            var result = new SaveResult<EmployerType>();

            try
            {
                var validation = _employerTypeValidator.Validate(employerType);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _employerRepository.SaveEmployerType(employerType);

                    result.Item = _employerRepository.GetEmployerType(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveEmployerType", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
