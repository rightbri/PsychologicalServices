using log4net;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.PhoneLogs
{
    public class PhoneLogService : IPhoneLogService
    {
        private readonly IPhoneLogRepository _phoneLogRepository = null;
        private readonly IPhoneLogValidator _phoneLogValidator = null;
        private readonly ILog _log = null;

        public PhoneLogService(
            IPhoneLogRepository phoneLogRepository,
            IPhoneLogValidator phoneLogValidator,
            ILog log
        )
        {
            _phoneLogRepository = phoneLogRepository;
            _phoneLogValidator = phoneLogValidator;
            _log = log;
        }

        public PhoneLog Get(int id)
        {
            var phoneLog = _phoneLogRepository.Get(id);

            if (phoneLog == null)
                throw new PhoneLogNotFoundException(id);

            return phoneLog;
        }

        public IEnumerable<PhoneLog> Get(PhoneLogSearchCriteria criteria)
        {
            return _phoneLogRepository.Get(criteria);
        }

        public SaveResult<PhoneLog> Save(PhoneLog phoneLog)
        {
            var result = new SaveResult<PhoneLog>();

            try
            {
                var validation = _phoneLogValidator.Validate(phoneLog);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _phoneLogRepository.Save(phoneLog);

                    result.Item = _phoneLogRepository.Get(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SavePhoneLog", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public DeleteResult Delete(int id)
        {
            var result = new DeleteResult();

            try
            {
                result.IsDeleted = _phoneLogRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _log.Error("DeletePhoneLog", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
